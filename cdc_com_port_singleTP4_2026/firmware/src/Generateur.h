#ifndef Generateur_h
#define Generateur_h

// TP3 MenuGen 2016
// C. HUBER  03.02.2016
// Fichier Generateur.h
// Prototypes des fonctions du générateur  de signal

#include <math.h>
#include <stdint.h>
#include <stdbool.h>

#include "DefMenuGen.h"

//définitions
#define AMPLITUDE_INIT 5000
#define AMPLI_MAX 20000
#define AMPLI_MAX_MOITIER 10000

#define DEUX 2

#define FREQUENCE_INIT 1000
#define FREQUENCE_MAX 800000

#define HALF_ECH 50
#define MAX_ECH 100
#define QUARTER_ECH 25

#define VAL_MAX 65536
#define VAL_MAX_MOINS_UN 65535
#define VAL_MOITIER 32768

#define UN 1
#define UN_SUR_DEUX 0.5

#define STEP_AMPLI 100      //Valeur en mV
#define STEP_FREQ 20        //Valeur en fréquence
#define STEP_OFFSET 100     //Valeur en mV

#define ZERO 0
// Initialisation du  générateur
void  GENSIG_Initialize(S_ParamGen *pParam);


// Mise à jour de la periode d'échantillonage
void  GENSIG_UpdatePeriode(S_ParamGen *pParam);


// Mise à jour du signal (forme, amplitude, offset)
void  GENSIG_UpdateSignal(S_ParamGen *pParam);

// A appeler dans int Timer3
void  GENSIG_Execute(void);


#endif