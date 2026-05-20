#ifndef Mc32GestI2CSEEPROM_H
#define Mc32GestI2CSEEPROM_H
/*--------------------------------------------------------*/
// Mc32GestI2cEEprom.h
/*--------------------------------------------------------*/
//	Description :	Gestion par I2C de l'EEPROM du MCP79411
//                      ( Exercice 9_1 )
//	Auteur 		: 	C. Huber
//	Version		:	V1.6    12.04.2016
//	Compilateur	:	XC32 V1.40 & Harmony 1_06
//
/*--------------------------------------------------------*/



#include <stdint.h>
// Adresse I2C pour la lecture depuis l'EEPROM du MCP79411 (7 bits + bit R/W à 1)
#define MCP79411_EEPROM_R    0xAF // Adresse I2C utilisée pour une lecture

// Adresse I2C pour l'écriture dans l'EEPROM du MCP79411 (7 bits + bit R/W à 0)
#define MCP79411_EEPROM_W    0xAE // Adresse I2C utilisée pour une écriture

// Adresse de début de l'EEPROM interne (0x00)
#define MCP79411_EEPROM_BEGINING  0x00 // Première adresse mémoire disponible

// Adresse de fin de l'EEPROM interne (0x7F pour 128 octets = 1 Kbits)
#define MCP79411_EEPROM_END  0x7F // Dernière adresse valide pour lecture/écriture

// prototypes des fonctions
void I2C_InitMCP79411(void);
void I2C_ReadSEEPROM(void *DstData, uint32_t EEpromAddr, uint16_t NbBytes);
void I2C_WriteSEEPROM(void *SrcData, uint32_t EEpromAddr, uint16_t NbBytes);

#endif