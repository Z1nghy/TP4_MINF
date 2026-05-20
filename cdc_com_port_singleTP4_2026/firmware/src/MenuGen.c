// ========================================================================
// Bibliothèques standard du C
// ========================================================================
#include <stdint.h>        //Définit les types d'entiers à taille fixe (ex: uint8_t, int16_t, uint32_t)
#include <stdbool.h>       //Ajoute le support du type booléen (bool, true, false)

// ========================================================================
// Bibliothèques spécifiques au projet (Matériel et Logique)
// ========================================================================
#include "Mc32DriverLcd.h" //Pilote pour contrôler l'affichage sur l'écran LCD
#include "GesPec12.h"      //Lib pour lire l'encodeur rotatif PEC12
#include "Mc32NVMUtil.h"   //Fonctions pour lire et écrire dans la mémoire (Note: à passer en I2C externe plus tard)
#include "Generateur.h"    
#include "MenuGen.h"       
#include "Mc32gestI2cSeeprom.h"
#include "Mc32_I2cUtilCCS.h"
static E_MenuState currentState = INIT_VALUE;
static int16_t backupValue = 0;

extern S_ParamGen LocalParamGen;
extern S_ParamGen RemoteParamGen;

static uint8_t saveOk = 0; 
static uint8_t attente_2s = 0;
static bool prev_local = true; // Pour détecter le changement d'état USB/Local

const char *MenuFormes[5] = {"Error","Sinus","Triangle","DentDeScie","Carre"};

// Nouveaux prototypes adaptés pour le TP4
void MENU_UpdateDisplay(S_ParamGen *pParam, bool local);
void MENU_DemandeSave(void);

S_ParamGen pParamSave; //Enregistres les valeurs sauvegardées

void MENU_Initialize(S_ParamGen *pParam)
{
    currentState = INIT_VALUE;
    MENU_UpdateDisplay(pParam, true); // Update de l'ecran au démarrage (supposé local par défaut)
    MENU_Execute(pParam, true);
}

// Nouvelle fonction demandée pour la sauvegarde via USB
void MENU_DemandeSave(void)
{
    saveOk = 1;              // Mémorise que c'est une demande de sauvegarde valide
    attente_2s = 0;          // Réinitialise le timer
    currentState = STATE_SAVEINFO; // Saute directement à l'affichage/écriture
}
void MENU_Execute(S_ParamGen *pParam, bool local)
{
    // Mode veille du backlight quand superieur a 5 seconde d'inactivite
    (Pec12NoActivity() && S9NoActivity()) ? lcd_bl_off() : lcd_bl_on();

    // -----------------------------------------------------------------
    // GESTION DU MODE USB (REMOTE)
    // -----------------------------------------------------------------
    if (!local)
    {
        // Si on vient juste de passer en mode USB, on met à jour l'affichage avec les '#'
        if (prev_local != local) {
            
            prev_local = local;
            
        }
        MENU_UpdateDisplay(&RemoteParamGen, local);
        // On purge les événements matériels pour éviter qu'ils ne s'accumulent 
        // et ne se déclenchent au débranchement de l'USB.
        Pec12ClearPlus(); Pec12ClearMinus(); Pec12ClearOK(); Pec12ClearESC(); S9ClearOK(); S9ClearESC();
        
        // Si une sauvegarde est en cours (déclenchée par l'USB), on laisse juste 
        // tourner la machine d'état sur STATE_SAVEINFO, sinon on bloque l'exécution ici.
        if (currentState != STATE_SAVEINFO)
        {
            return; 
        }
    }
    else
    {
        // Si on vient de repasser en mode Local, on rafraîchit l'écran avec les '*'
        if (prev_local != local) {
            MENU_UpdateDisplay(&RemoteParamGen, local);
            prev_local = local;
        }
    }

    // --- MACHINE D'ÉTAT ---
    switch (currentState)
    {
        // -----------------------------------------------------------------
        // ÉTATS DE DEPART 
        // -----------------------------------------------------------------
        case INIT_VALUE: 
            
            I2C_ReadSEEPROM(&pParamSave,MCP79411_EEPROM_BEGINING,sizeof(S_ParamGen) );
            if (pParamSave.Magic == MAGIC)
            {
                *pParam = pParamSave;
            }
            else
            {
                pParam->Forme = 1;          
                pParam->Frequence = 1000;   
                pParam->Amplitude = 5000;   
                pParam->Offset = 0;         
                pParam->Magic = MAGIC;      
            }
            
            GENSIG_UpdatePeriode(pParam);   
            GENSIG_UpdateSignal(pParam);    
            currentState = STATE_NAV_FORME; 
            MENU_UpdateDisplay(pParam, local);      
        break;  
        
        // -----------------------------------------------------------------
        // ÉTATS DE NAVIGATION 
        // -----------------------------------------------------------------
        case STATE_NAV_FORME:
            if (Pec12IsPlus())
            {
                currentState = STATE_NAV_FREQ;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearPlus();
            }
            else if (Pec12IsMinus())
            { 
                currentState = STATE_NAV_OFFSET;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearMinus();
            }
            else if (Pec12IsOK()) 
            {
                backupValue = pParam->Forme;
                currentState = STATE_EDIT_FORME;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearOK();
            }
            else if (S9IsOK())
            {
                currentState = STATE_SAUVEGARDE;
                MENU_UpdateDisplay(pParam, local);      
                S9ClearOK();
            }            
            break;

        case STATE_NAV_FREQ:
            if (Pec12IsPlus())
            { 
                currentState = STATE_NAV_AMPL;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearPlus();
            }
            else if (Pec12IsMinus()) 
            { 
                currentState = STATE_NAV_FORME;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearMinus();
            }
            else if (Pec12IsOK()) 
            {
                backupValue = pParam->Frequence;
                currentState = STATE_EDIT_FREQ; 
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearOK();
            }
            else if (S9IsOK())
            {
                currentState = STATE_SAUVEGARDE;
                MENU_UpdateDisplay(pParam, local);      
                S9ClearOK();
            }            
            break;

        case STATE_NAV_AMPL:
            if (Pec12IsPlus())
            {
                currentState = STATE_NAV_OFFSET;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearPlus();
            }
            else if (Pec12IsMinus())
            { 
                currentState = STATE_NAV_FREQ;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearMinus();
            }
            else if (Pec12IsOK())
            {
                backupValue = pParam->Amplitude;
                currentState = STATE_EDIT_AMPL;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearOK();
            }
            else if (S9IsOK())
            {
                currentState = STATE_SAUVEGARDE;
                MENU_UpdateDisplay(pParam, local);      
                S9ClearOK();
            }
            break;

        case STATE_NAV_OFFSET:
            if (Pec12IsPlus())
            {
                currentState = STATE_NAV_FORME;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearPlus();
            }
            else if (Pec12IsMinus())
            {
                currentState = STATE_NAV_AMPL;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearMinus();
            }
            else if (Pec12IsOK())
            { 
                backupValue = pParam->Offset;
                currentState = STATE_EDIT_OFFSET;
                MENU_UpdateDisplay(pParam, local);      
                Pec12ClearOK();
            }
            else if (S9IsOK())
            {
                currentState = STATE_SAUVEGARDE;
                MENU_UpdateDisplay(pParam, local);      
                S9ClearOK();
            }
            break;

        // -----------------------------------------------------------------
        // ÉTATS D'ÉDITION 
        // -----------------------------------------------------------------
        case STATE_EDIT_FORME:
            if (Pec12IsPlus())
            {
                pParam->Forme++;
                if (pParam->Forme > 4) pParam->Forme = 1;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearPlus();
            }
            else if (Pec12IsMinus())
            {
                pParam->Forme--;
                if (pParam->Forme < 1) pParam->Forme = 4;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearMinus();
            }
            else if (Pec12IsOK())
            {
                GENSIG_UpdateSignal(pParam);    
                currentState = STATE_NAV_FORME;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearOK();
            }
            else if (Pec12IsESC())
            {
                pParam->Forme = backupValue; 
                currentState = STATE_NAV_FORME;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearESC();
            }
            else if (S9IsOK())
            {
                currentState = STATE_SAUVEGARDE;
                MENU_UpdateDisplay(pParam, local); 
                S9ClearOK();
            }
            break;

        case STATE_EDIT_FREQ:
            if (Pec12IsPlus())
            {
                pParam->Frequence += 20; 
                if (pParam->Frequence > 2000) pParam->Frequence = 20; 
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearPlus();
            }
            else if (Pec12IsMinus())
            {
                pParam->Frequence -= 20;
                if (pParam->Frequence < 20) pParam->Frequence = 2000;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearMinus();
            }
            else if (Pec12IsOK())
            {
                GENSIG_UpdatePeriode(pParam);   
                currentState = STATE_NAV_FREQ;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearOK();
            }
            else if (Pec12IsESC())
            {
                pParam->Frequence = backupValue; 
                currentState = STATE_NAV_FREQ;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearESC();
            }
            else if (S9IsOK())
            {
                currentState = STATE_SAUVEGARDE;
                MENU_UpdateDisplay(pParam, local); 
                S9ClearOK();
            }
            break;

        case STATE_EDIT_AMPL:
            if (Pec12IsPlus())
            {
                pParam->Amplitude += 100; 
                if (pParam->Amplitude > 10000) pParam->Amplitude = 0; 
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearPlus();
            }
            else if (Pec12IsMinus())
            {
                pParam->Amplitude -= 100;
                if (pParam->Amplitude < 0) pParam->Amplitude = 10000;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearMinus();
            }
            else if (Pec12IsOK())
            {
                GENSIG_UpdateSignal(pParam);    
                currentState = STATE_NAV_AMPL;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearOK();
            }
            else if (Pec12IsESC())
            {
                pParam->Amplitude = backupValue; 
                currentState = STATE_NAV_AMPL;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearESC();
            }
            else if (S9IsOK())
            {
                currentState = STATE_SAUVEGARDE;
                MENU_UpdateDisplay(pParam, local); 
                S9ClearOK();
            }            
            break;

        case STATE_EDIT_OFFSET:
            if (Pec12IsPlus())
            {
                pParam->Offset += 100; 
                if (pParam->Offset > 5000) pParam->Offset = 5000; 
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearPlus();
            }
            else if (Pec12IsMinus())
            {
                pParam->Offset -= 100;
                if (pParam->Offset < -5000) pParam->Offset = -5000; 
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearMinus();
            }
            else if (Pec12IsOK())
            {
                GENSIG_UpdateSignal(pParam);    
                currentState = STATE_NAV_OFFSET;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearOK();
            }
            else if (Pec12IsESC())
            {
                pParam->Offset = backupValue; 
                currentState = STATE_NAV_OFFSET;
                MENU_UpdateDisplay(pParam, local); 
                Pec12ClearESC();
            }
            else if (S9IsOK())
            {
                currentState = STATE_SAUVEGARDE;
                MENU_UpdateDisplay(pParam, local); 
                S9ClearOK();
            }            
            break;
            
        // -----------------------------------------------------------------
        // ÉTATS DE SAUVEGARDE
        // -----------------------------------------------------------------
        case STATE_SAUVEGARDE:
            if (S9IsESC())
            {
                saveOk = 1;      
                attente_2s = 0;      
                currentState = STATE_SAVEINFO;
                MENU_UpdateDisplay(pParam, local); 
                S9ClearESC();
                S9ClearOK();
            }
            else if (S9IsOK() || Pec12IsPlus() || Pec12IsMinus() || Pec12IsOK() || Pec12IsESC())
            {
                saveOk = 0;      
                attente_2s = 0;      
                currentState = STATE_SAVEINFO;
                MENU_UpdateDisplay(pParam, local); 
                S9ClearOK(); Pec12ClearPlus(); Pec12ClearMinus(); Pec12ClearOK(); Pec12ClearESC();
            }
            break;

        case STATE_SAVEINFO:
            if (attente_2s == 0 && saveOk == 1)
            {
                pParam->Magic = MAGIC;
                I2C_WriteSEEPROM(pParam, MCP79411_EEPROM_BEGINING, sizeof(S_ParamGen));
            }
            attente_2s++; 
            if (attente_2s >= 200)
            {
                currentState = STATE_NAV_FORME; 
                
                MENU_UpdateDisplay(pParam, local); 
            }
            break;
    }
}

void MENU_UpdateDisplay(S_ParamGen *pParam, bool local)
{
    if (currentState == STATE_SAUVEGARDE)
    {
        uint8_t i; 
        for (i = 1; i <= 4; i++) { lcd_ClearLine(i); }
        lcd_gotoxy(5, 2); 
        printf_lcd("Sauvegarde ?"); 
        lcd_gotoxy(5, 3); 
        printf_lcd("(appui long)");
        return; 
    } 
    else if (currentState == STATE_SAVEINFO)
    {
        uint8_t i; 
        for (i = 1; i <= 4; i++) { lcd_ClearLine(i); }
        lcd_gotoxy(4, 2); 
        if (saveOk) {
            printf_lcd("Sauvegarde OK"); 
        } else {
            lcd_gotoxy(2, 2); 
            printf_lcd("Sauvegarde ANNULEE"); 
        }
        return; 
    }
    
    char selForme = ' ', selFreq = ' ', selAmpl = ' ', selOff = ' ';
    
    // Modification TP4 : Affichage des '#' si le mode est remote (USB)
    if (!local) 
    {
        selForme = '#';
        selFreq  = '#';
        selAmpl  = '#';
        selOff   = '#';
//        
    }
    else 
    {
        // Fonctionnement standard en local
        switch (currentState)
        {
            case STATE_NAV_FORME:   selForme = '*'; break;
            case STATE_EDIT_FORME:  selForme = '?'; break;

            case STATE_NAV_FREQ:    selFreq = '*';  break;
            case STATE_EDIT_FREQ:   selFreq = '?';  break;

            case STATE_NAV_AMPL:    selAmpl = '*';  break;
            case STATE_EDIT_AMPL:   selAmpl = '?';  break;

            case STATE_NAV_OFFSET:  selOff = '*';   break;
            case STATE_EDIT_OFFSET: selOff = '?';   break;

            default: break; 
        }
    }

    lcd_gotoxy(1, 1);
    printf_lcd("%cForme = %-10s", selForme, MenuFormes[pParam->Forme]);
    
    lcd_gotoxy(1, 2);
    printf_lcd("%cFreq[Hz]= %-7d ", selFreq, pParam->Frequence);
    
    lcd_gotoxy(1, 3);
    printf_lcd("%cAmpl[mV]= %-5d ", selAmpl, pParam->Amplitude);
    
    lcd_gotoxy(1, 4);
    printf_lcd("%cOffset  = %-5d ", selOff, pParam->Offset);
    

}