// Mc32Gest_SerComm.C
// fonction d'émission et de réception des message
// transmis en USB CDC
// Canevas TP4 SLO2 2015-2015


#include "app.h"
#include "Mc32gest_SerComm.h"
#include <string.h>
#include <stdio.h>
#include <stdlib.h>

extern APP_DATA appData;
// Fonction de reception  d'un  message
// Met à jour les paramètres du generateur a partir du message recu
// Format du message
//  !S=TF=2000A=10000O=+5000D=100W=0#
//  !S=PF=2000A=10000O=-5000D=100W=1#


bool GetMessage(int8_t *USBReadBuffer, S_ParamGen *pParam, bool *SaveTodo)
{
    // Déclaration des pointeurs vers les différentes sections de la trame
    char *pt_Forme = NULL;       // Pointeur vers le champ S= (forme du signal)
    char *pt_Frequence = NULL;   // Pointeur vers le champ F= (fréquence)
    char *pt_Amplitude = NULL;   // Pointeur vers le champ A= (amplitude)
    char *pt_Offset = NULL;      // Pointeur vers le champ O= (offset)
    char *pt_Sauvegarde = NULL;  // Pointeur vers le champ W= (demande de sauvegarde)

    // Étape 1 : Vérifie le début et la fin de la trame
    // Une trame valide commence par '!' et contient un '#' de terminaison
    if (USBReadBuffer[0] != '!')
    {
        return false; // La trame ne commence pas par le caractère '!'
    }

    if (strchr((char*)USBReadBuffer, '#') == NULL)
    {
        return false; // Le caractère '#' de fin de trame est manquant
    }

    // Étape 2 : Recherche des champs spécifiques dans la trame
    // Utilisation de strstr pour localiser chaque paramètre attendu
    pt_Forme      = strstr((char*)USBReadBuffer, "S="); // Forme du signal (S=)
    pt_Frequence  = strstr((char*)USBReadBuffer, "F="); // Fréquence (F=)
    pt_Amplitude  = strstr((char*)USBReadBuffer, "A="); // Amplitude (A=)
    pt_Offset     = strstr((char*)USBReadBuffer, "O="); // Offset (O=)
    pt_Sauvegarde = strstr((char*)USBReadBuffer, "W="); // Sauvegarde (W=)

    // Vérifie que tous les champs ont bien été trouvés
    if (!pt_Forme || !pt_Frequence || !pt_Amplitude || !pt_Offset || !pt_Sauvegarde)
    {
        return false; // Un ou plusieurs champs obligatoires sont absents
    }

    // Étape 3 : Décodage de la forme du signal
    // Le caractère juste après 'S=' détermine le type de forme
    // Exemples : T = Triangle, S = Sinus, C = Carré, D = Dent de scie
    switch (pt_Forme[2])
    {
        case 'T':
            pParam->Forme = SignalTriangle;    // Signal de forme triangulaire
            break;
        case 'S':
            pParam->Forme = SignalSinus;       // Signal de forme sinusoïdale
            break;
        case 'C':
            pParam->Forme = SignalCarre;       // Signal de forme carrée
            break;
        case 'D':
            pParam->Forme = SignalDentDeScie;  // Signal de forme dent de scie
            break;
        default:
            return false; // Caractère de forme inconnu, trame invalide
    }

    // Étape 4 : Extraction et conversion des valeurs numériques
    // On extrait les entiers avec atoi en sautant les 2 premiers caractères (ex: F=)
    pParam->Frequence = atoi(pt_Frequence + 2);   // Fréquence en [Hz]
    pParam->Amplitude = atoi(pt_Amplitude + 2);   // Amplitude en [mV]
    pParam->Offset    = atoi(pt_Offset + 2);      // Offset en [mV]

    // Étape 5 : Analyse du champ W= pour savoir si une sauvegarde est demandée
    int wVal = atoi(pt_Sauvegarde + 2); // Récupère la valeur 0 ou 1 après W=
    if (wVal == 1)
    {
        *SaveTodo = true;  // Indique qu'une sauvegarde doit être effectuée
    }
    else
    {
        *SaveTodo = false; // Aucune demande de sauvegarde
    }

    // Étape 6 : Tous les champs sont valides et correctement traités
    return true; // Trame décodée avec succès
}
    


// Fonction d'envoi d'un  message
// Rempli le tampon d'émission pour USB en fonction des paramètres du générateur
// Format du message
// !S=TF=2000A=10000O=+5000D=25WP=0#
// !S=TF=2000A=10000O=+5000D=25WP=1#    // ack sauvegarde

void SendMessage(int8_t *USBSendBuffer, S_ParamGen *pParam, bool Saved )
{
     LED5_W = 1;
    char *infoSignal;  // Lettre représentant la forme du signal
   
    // Détermination de la lettre à utiliser selon la forme actuelle
    switch (pParam->Forme)
    {
        case SignalTriangle:   
            infoSignal = "T"; 
            break;
        case SignalSinus: 
            infoSignal = "S"; 
            break;
        case SignalCarre:      
            infoSignal = "C"; 
            break;
        case SignalDentDeScie: 
            infoSignal = "D"; 
            break;
        default:
            infoSignal = "S"; 
            break;  // Défaut = Sinus
        
    }
       
    // CORRECTION ICI : Ajout de (char*)USBSendBuffer, du 'W' et du '\r\n' !
    sprintf((char*)USBSendBuffer, "!S=%sF=%dA=%dO=%dW=%d#\r\n", infoSignal, pParam->Frequence, pParam->Amplitude, pParam->Offset, Saved);
    
    // Détermine la longueur de la chaîne créée
    //size_t len = strlen((char*)USBSendBuffer);

    // On change l'état pour indiquer qu'on attend la fin de l'envoi
    //appData.state = APP_STATE_WAIT_FOR_WRITE_COMPLETE;

    LED5_W = 0;
} 


