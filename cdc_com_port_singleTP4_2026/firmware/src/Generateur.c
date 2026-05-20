// Canevas manipulation GenSig avec menu
// C. HUBER  09/02/2015
// Fichier Generateur.C
// Gestion  du générateur

// Prévu pour signal de 40 echantillons

// Migration sur PIC32 30.04.2014 C. Huber


#include "Generateur.h"
#include "DefMenuGen.h"
#include "Mc32gestSpiDac.h"
#include "app.h"
#include "Mc32NVMUtil.h"
#include "math.h"

// T.P. 2016 100 echantillons

//Déclaration du tableau d'échantillonage
int32_t tabEch[MAX_ECH];


const int16_t tbSinus[100] = {
    53, 56, 59, 62, 65, 68, 71, 74, 77, 79, 82, 84, 86, 89, 90, 92, 94, 95, 96, 98, 
    98, 99, 100, 100, 100, 100, 100, 99, 98, 98, 96, 95, 94, 92, 90, 89, 86, 
    84, 82, 79, 77, 74, 71, 68, 65, 62, 59, 56, 53, 50, 47, 44, 41, 38, 35, 
    32, 29, 26, 23, 21, 18, 16, 14, 11, 10, 8, 6, 5, 4, 2, 2, 1, 0, 0, 0, 0, 
    1, 1, 2, 2, 3, 4, 6, 8, 10, 11, 14, 16, 18, 21, 23, 26, 29, 32, 35, 38, 
    41, 44, 47, 50};


// Initialisation du  générateur
void  GENSIG_Initialize(S_ParamGen *pParam)
{
    S_ParamGen s_Parametres;
    if (s_Parametres.Magic == MAGIC)
    {
        *pParam = s_Parametres;
    }
    else
    {
        // Valeurs par défaut au démarrage
        pParam->Forme = SignalSinus;              // Sinus
        pParam->Frequence = FREQUENCE_INIT;       // 1 kHz
        pParam->Amplitude = AMPLITUDE_INIT;       // 5000 mV
        pParam->Offset = ZERO;                    // 0 mV
        pParam->Magic = ZERO; 
    }
    
    GENSIG_UpdatePeriode(pParam); // Mise à jour du timer 
    GENSIG_UpdateSignal(pParam); // Mise à jour du timer 
}
  

// Mise à jour de la periode d'échantillonage
void  GENSIG_UpdatePeriode(S_ParamGen *pParam)
{
    uint16_t compteurTimerFrequence = ZERO;
    compteurTimerFrequence = (uint16_t)((((float)FREQUENCE_MAX / (float)pParam->Frequence) - (float)UN) + (float)UN_SUR_DEUX);
    PLIB_TMR_Period16BitSet(TMR_ID_3, compteurTimerFrequence);
}

// Mise à jour du signal (forme, amplitude, offset)
void  GENSIG_UpdateSignal(S_ParamGen *pParam)
{
    uint8_t i = ZERO;
    int32_t PlaceHolder = ZERO;
    float Val_Ampli = ((float)pParam->Amplitude / (float)MAX_ECH)* (float)DEUX;      //en mV
    
    for(i = ZERO; i < MAX_ECH; i++)
    {
        switch(pParam->Forme)
        {
            case SignalSinus:
                
                PlaceHolder = (int32_t)((float)(tbSinus[i] - (float)HALF_ECH) * Val_Ampli + (float)AMPLI_MAX_MOITIER - (float)pParam->Offset);
                if(PlaceHolder > VAL_MAX_MOINS_UN)
                {
                    PlaceHolder = VAL_MAX_MOINS_UN;
                }
                if (PlaceHolder < ZERO) 
                {
                    PlaceHolder = UN;
                }
                tabEch[i] = PlaceHolder;
                
                
                if ((tabEch[i] >= AMPLI_MAX) && (pParam->Offset < false)) 
                {
                    tabEch[i] = VAL_MAX_MOINS_UN;
                }
                else if ((tabEch[i] >= AMPLI_MAX) && (pParam->Offset > false))
                {
                    tabEch[i] = AMPLI_MAX; 
                }
                tabEch[i] = (((VAL_MAX * tabEch[i]) - UN) / AMPLI_MAX);
                break;

                
                
                
                
                
            case SignalTriangle:
                if(HALF_ECH < i)
                {
                    PlaceHolder = (int32_t)((int16_t)Val_Ampli * ((int16_t)MAX_ECH - (int16_t)DEUX * ((int16_t)i - (int16_t)QUARTER_ECH)) + (int16_t)AMPLI_MAX_MOITIER  - pParam->Offset);   
                }
                else
                {
                    PlaceHolder = (int32_t)((int16_t)Val_Ampli * ((int16_t)DEUX * ((int16_t)i - (int16_t)QUARTER_ECH)) + (int16_t)AMPLI_MAX_MOITIER - (int16_t)pParam->Offset);
                }
                
                if(PlaceHolder > VAL_MAX_MOINS_UN)
                {
                    PlaceHolder = VAL_MAX_MOINS_UN;
                }
                if (PlaceHolder < ZERO)
                {
                    PlaceHolder = UN;
                }
                tabEch[i] = PlaceHolder;
                
                
                if ((tabEch[i] >= AMPLI_MAX) && (pParam->Offset < false)) 
                {
                    tabEch[i] = VAL_MAX_MOINS_UN;
                }
                else if ((tabEch[i] >= AMPLI_MAX) && (pParam->Offset > false))
                {
                    tabEch[i] = AMPLI_MAX; 
                }
                tabEch[i] = (((VAL_MAX * tabEch[i]) - UN) / AMPLI_MAX);
                break;

                
                
                
                
                
            case SignalDentDeScie:
                PlaceHolder = (int32_t)(((int16_t)i - (int16_t)HALF_ECH) * (int16_t)Val_Ampli + (int16_t)AMPLI_MAX_MOITIER - pParam->Offset);
                if(PlaceHolder > VAL_MAX_MOINS_UN)
                {
                    PlaceHolder = VAL_MAX_MOINS_UN;
                }
                if (PlaceHolder < ZERO) 
                {
                    PlaceHolder = UN;
                }
                tabEch[i] = PlaceHolder;
                
                if ((tabEch[i] >= AMPLI_MAX) && (pParam->Offset < false)) 
                {
                    tabEch[i] = VAL_MAX_MOINS_UN;
                }
                else if ((tabEch[i] >= AMPLI_MAX) && (pParam->Offset > false))
                {
                    tabEch[i] = AMPLI_MAX; 
                }
                tabEch[i] = (((VAL_MAX * tabEch[i]) - UN) / AMPLI_MAX); 
                break;

                
                
                
                
                
            case SignalCarre:
                
                if(i < HALF_ECH)
                {
                    PlaceHolder = (int32_t)((int16_t)AMPLI_MAX_MOITIER - ((int16_t)Val_Ampli * (int16_t)MAX_ECH / (int16_t)DEUX) - (int16_t)pParam->Offset);
                    
                }
                else
                {
                    PlaceHolder = (int32_t)((int16_t)AMPLI_MAX_MOITIER +((int16_t)Val_Ampli * (int16_t)MAX_ECH / (int16_t)DEUX) - (int16_t)pParam->Offset);
                    
                }
                
                if(PlaceHolder > VAL_MAX_MOINS_UN)
                {
                    PlaceHolder = VAL_MAX_MOINS_UN;
                }
                if (PlaceHolder < ZERO) 
                {
                    PlaceHolder = UN;
                }
                tabEch[i] = PlaceHolder;
                
                
               
                if ((tabEch[i] >= AMPLI_MAX) && (pParam->Offset < false)) 
                {
                    tabEch[i] = VAL_MAX_MOINS_UN;
                }
                else if ((tabEch[i] >= AMPLI_MAX) && (pParam->Offset > false))
                {
                    tabEch[i] = AMPLI_MAX; 
                }
                tabEch[i] = (((VAL_MAX * tabEch[i]) - UN) / AMPLI_MAX);
                break;

                
                
                
                
                
            default:
                /*On ne fait rien dans le cas default*/
                break;
        }
    }
}


// Execution du générateur
// Fonction appelée dans Int timer3 (cycle variable variable)

// Version provisoire pour test du DAC à modifier
void  GENSIG_Execute(void)
{
    LED7_W = 1;
    static uint16_t EchNb = ZERO;
 
    if (EchNb >= MAX_ECH) 
    {
        EchNb = ZERO; // Réinitialisation
    }
 
    SPI_WriteToDac(ZERO, tabEch[EchNb] );      // sur canal 0
    EchNb++;
    EchNb = EchNb % MAX_ECH;
    LED7_W = 0;
}
