#ifndef MenuGen_h
#define MenuGen_h

// Tp3  manipulation MenuGen avec PEC12
// C. HUBER  03.02.2016
// Fichier MenuGen.h
// Gestion du menu  du générateur
// Traitement cyclique à 1 ms du Pec12


#include <stdbool.h>
#include <stdint.h>
#include "DefMenuGen.h"

// Constantes 
#define MAGIC 0x123455AA   // Valeur constante pour vérifier la validité de la sauvegarde en mémoire

typedef enum {
    STATE_NAV_FORME,
    STATE_NAV_FREQ,
    STATE_NAV_AMPL,
    STATE_NAV_OFFSET,
    STATE_EDIT_FORME,
    STATE_EDIT_FREQ,
    STATE_EDIT_AMPL,
    STATE_EDIT_OFFSET,
    STATE_SAVEINFO,
    STATE_SAUVEGARDE, 
    INIT_VALUE        
} E_MenuState;

void MENU_Initialize(S_ParamGen *pParam);    //Initialise la machine d'état
void MENU_UpdateDisplay(S_ParamGen *pParam, bool local); //Update l'écran LCD 
void MENU_Execute(S_ParamGen *pParam, bool local);     //Execute la logique et la navigation du menu
void MENU_DemandeSave(void);                 //Sauvegarde les information 
void MENU_UnDemandeSave(void);
#endif




  
   







