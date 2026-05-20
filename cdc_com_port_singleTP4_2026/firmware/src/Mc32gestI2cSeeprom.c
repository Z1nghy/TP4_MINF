#include "Mc32gestI2cSeeprom.h"
#include "Mc32_I2cUtilCCS.h"
#include "bsp.h"
#include <stdio.h>

// Adresses I2C du MCP79411
#define MCP79411_EEPROM_R    0xAF  // Lecture
#define MCP79411_EEPROM_W    0xAE  // Ecriture
#define MCP79411_EEPROM_BEG  0x00  // Début mémoire
#define MCP79411_EEPROM_END  0x7F  // Fin mémoire

// Initialisation de l'I2C
void I2C_InitMCP79411(void)
{
   bool Fast = true;
   i2c_init(Fast);
}

// Ecriture d'un bloc de données dans l'EEPROM
void I2C_WriteSEEPROM(void *SrcData, uint32_t EEpromAddr, uint16_t NbBytes)
{
    uint8_t *pData = (uint8_t *)SrcData;
    uint16_t i;
    uint8_t ack_status;

    for (i = 0; i < NbBytes; i++) 
    {
        // 1. Envoi d'un octet
        i2c_start();                                 // Prend le contrôle du bus
        i2c_write(MCP79411_EEPROM_W);                // Appelle la puce en mode "Ecriture"
        i2c_write((uint8_t)(EEpromAddr + i));        // Envoie l'adresse de la case mémoire cible
        i2c_write(pData[i]);                         // Envoie l'octet de donnée à sauvegarder
        i2c_stop();                                  // Libère le bus temporairement
        
        // 2. Attente de la fin de l'écriture (ACK Polling)
        do 
        {
            i2c_start(); 
            ack_status = i2c_write(MCP79411_EEPROM_W); 
            i2c_stop(); 

        } while (ack_status == 0); // Tant qu'elle ecrit 

        i2c_stop();
    }
}

// Lecture d'un bloc de données depuis l'EEPROM
void I2C_ReadSEEPROM(void *DstData, uint32_t EEpromAddr, uint16_t NbBytes)
{
    uint8_t *pData = (uint8_t *)DstData;
    uint16_t i;

    if (NbBytes == 0) return;

    // 1. Positionnement sur l'adresse à lire
    i2c_start();                                 
    i2c_write(MCP79411_EEPROM_W);      // On l'appelle maintenant en mode ecriture         
    i2c_write((uint8_t)EEpromAddr);              

    // 2. Lecture séquentielle
    i2c_reStart();                                 
    i2c_write(MCP79411_EEPROM_R);      // On l'appelle maintenant en mode lecture          

    for (i = 0; i < NbBytes; i++) 
    {
        // Dernier octet -> NACK (0), sinon ACK (1)
        if (i == (NbBytes - 1)) 
        {
            pData[i] = i2c_read(0);              
        } 
        else 
        {
            pData[i] = i2c_read(1);              
        }
    }
    
    i2c_stop();  
}