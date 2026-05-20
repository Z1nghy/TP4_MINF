/*******************************************************************************
  MPLAB Harmony Application Source File
  
  Company:
    Microchip Technology Inc.
  
  File Name:
    appgen.c

  Summary:
    This file contains the source code for the MPLAB Harmony application.

  Description:
    This file contains the source code for the MPLAB Harmony application.  It 
    implements the logic of the application's state machine and it may call 
    API routines of other MPLAB Harmony modules in the system, such as drivers,
    system services, and middleware.  However, it does not call any of the
    system interfaces (such as the "Initialize" and "Tasks" functions) of any of
    the modules in the system or make any assumptions about when those functions
    are called.  That is the responsibility of the configuration-specific system
    files.
 *******************************************************************************/

// DOM-IGNORE-BEGIN
/*******************************************************************************
Copyright (c) 2013-2014 released Microchip Technology Inc.  All rights reserved.

Microchip licenses to you the right to use, modify, copy and distribute
Software only when embedded on a Microchip microcontroller or digital signal
controller that is integrated into your product or third party product
(pursuant to the sublicense terms in the accompanying license agreement).

You should refer to the license agreement accompanying this Software for
additional information regarding your rights and obligations.

SOFTWARE AND DOCUMENTATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION, ANY WARRANTY OF
MERCHANTABILITY, TITLE, NON-INFRINGEMENT AND FITNESS FOR A PARTICULAR PURPOSE.
IN NO EVENT SHALL MICROCHIP OR ITS LICENSORS BE LIABLE OR OBLIGATED UNDER
CONTRACT, NEGLIGENCE, STRICT LIABILITY, CONTRIBUTION, BREACH OF WARRANTY, OR
OTHER LEGAL EQUITABLE THEORY ANY DIRECT OR INDIRECT DAMAGES OR EXPENSES
INCLUDING BUT NOT LIMITED TO ANY INCIDENTAL, SPECIAL, INDIRECT, PUNITIVE OR
CONSEQUENTIAL DAMAGES, LOST PROFITS OR LOST DATA, COST OF PROCUREMENT OF
SUBSTITUTE GOODS, TECHNOLOGY, SERVICES, OR ANY CLAIMS BY THIRD PARTIES
(INCLUDING BUT NOT LIMITED TO ANY DEFENSE THEREOF), OR OTHER SIMILAR COSTS.
 *******************************************************************************/
// DOM-IGNORE-END


// *****************************************************************************
// *****************************************************************************
// Section: Included Files 
// *****************************************************************************
// *****************************************************************************

#include "appgen.h"
#include "Mc32DriverLcd.h"
#include "Mc32gestSpiDac.h"
#include "GesPec12.h"
#include "Generateur.h"
#include "MenuGen.h"
#include "app.h"
#include <stdbool.h>
#include "Mc32gestI2cSeeprom.h"

// *****************************************************************************
// *****************************************************************************
// Section: Global Data Definitions
// *****************************************************************************
// *****************************************************************************

// *****************************************************************************
/* Application Data

  Summary:
    Holds application data

  Description:
    This structure holds the application's data.

  Remarks:
    This structure should be initialized by the APP_Initialize function.
    
    Application strings and buffers are be defined outside this structure.
*/

APPGEN_DATA appgenData;
APP_DATA appData;
S_ParamGen LocalParamGen;
S_ParamGen RemoteParamGen;
// *****************************************************************************
// *****************************************************************************
// Section: Application Callback Functions
// *****************************************************************************
// *****************************************************************************
void CallBack_Timer1()
{
    // toggle de la LED 1 
    BSP_LEDToggle(BSP_LED_1);
    ScanPec12(PEC12_A, PEC12_B, PEC12_PB, S_OK);

    // variable initialisé une seul fois
    static uint16_t timer_count_1ms = ZERO;
    static uint8_t timer_count_10ms = ZERO;
    // tant que le nombre de ticks n'est pas équivalent a une durée de 20ms le 
    // timer_count_20ms est incrémenté de 1. quand le nombre de ticks est équivalent
    // a 20ms la fonction GPWM_ExecPWMSoft est appelée.
    if (timer_count_1ms < T_INIT) 
    {
        timer_count_1ms++;
    }
    else 
    {
        if (timer_count_10ms < T_DIX_CYCLE) 
        {
            timer_count_10ms++;
        }
        else 
        {
            APP_UpdateState(APP_STATE_SERVICE_TASKS);
            timer_count_10ms = ZERO;
        }
    }
     
}
/******************************************************************************/

/******************************* Call back timer 3 ****************************/
void CallBack_Timer3()
{
    LED0_W = 1;
    GENSIG_Execute();
    LED0_W = 0;
     
}
/* TODO:  Add any necessary callback functions.
*/

// *****************************************************************************
// *****************************************************************************
// Section: Application Local Functions
// *****************************************************************************
// *****************************************************************************
void APP_UpdateState ( APPGEN_STATES NewState )
{
    appgenData.state = NewState;
}

/* TODO:  Add any necessary local functions.
*/


// *****************************************************************************
// *****************************************************************************
// Section: Application Initialization and State Machine Functions
// *****************************************************************************
// *****************************************************************************

/*******************************************************************************
  Function:
    void APPGEN_Initialize ( void )

  Remarks:
    See prototype in appgen.h.
 */

void APPGEN_Initialize ( void )
{
    /* Place the App state machine in its initial state. */
    appgenData.state = APPGEN_STATE_INIT;

    
    /* TODO: Initialize your application's state machine and other
     * parameters.
     */
}


/******************************************************************************
  Function:
    void APPGEN_Tasks ( void )

  Remarks:
    See prototype in appgen.h.
 */

void APPGEN_Tasks ( void )
{

    /* Check the application's current state. */
    switch ( appgenData.state )
    {
        /* Application's initial state. */
        case APP_STATE_INIT:
        {    
            static uint16_t startCount = 0;
            lcd_init();
            lcd_bl_on();

            // Init SPI DAC
            SPI_InitLTC2604();
            //Init eeprom
            I2C_InitMCP79411();
            // Initialisation PEC12
            Pec12Init();
            // Initialisation du generateur
            GENSIG_Initialize(&LocalParamGen);
            // Initialisation du menu
            MENU_Initialize(&LocalParamGen);
            if(startCount <= 3000)
            {
                lcd_gotoxy(1,1);
                printf_lcd("TP4 GenSig <2026>");
                // A adapter pour les 2 noms sur 2 lignes
                lcd_gotoxy(1,2);
                printf_lcd("Alan Badertscher");
                lcd_gotoxy(1,3);
                printf_lcd("Diego Alec Savary"); 
                lcd_ClearLine(4);
                startCount ++;
            }
            // Active les timers 
            DRV_TMR0_Start();
            DRV_TMR1_Start();
            APP_UpdateState(APP_STATE_WAIT);
            break;
        }
        case APP_STATE_WAIT :
            // nothing to do
            break;

        case APP_STATE_SERVICE_TASKS:
           
           // Execution du menu 
            if (appData.usbStat) 
            { 
                GENSIG_UpdatePeriode(&RemoteParamGen);
                GENSIG_UpdateSignal(&RemoteParamGen);
                MENU_Execute(&RemoteParamGen, false);
                
            } 
            else 
            { 
                GENSIG_UpdatePeriode(&LocalParamGen);
                GENSIG_UpdateSignal(&LocalParamGen);
                MENU_Execute(&LocalParamGen, true); 
                
            }

            BSP_LEDToggle(BSP_LED_2);
            APP_UpdateState(APP_STATE_WAIT);
            break;

        /* TODO: implement your application state machine.*/
        

        /* The default state should never be executed. */
        default:
        {
            /* TODO: Handle error in application's state machine. */
            break;
        }
    }
}

 

/*******************************************************************************
 End of File
 */
