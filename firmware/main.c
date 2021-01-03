/* Name: main.c
 * Project: GeigerMuellerCounter
 * Author: Phillip Durdaut
 * Based on "custom-class, a basic USB example" by Christian Starkjohann
 * Creation Date: 2008-04-09
 * Tabsize: 4
 * Copyright: (c) 2008 by OBJECTIVE DEVELOPMENT Software GmbH
 * License: GNU GPL v2 (see License.txt), GNU GPL v3 or proprietary (CommercialLicense.txt)
 */

#define F_CPU 12000000UL

#define LED_PORT_DDR				DDRD
#define LED_PORT_OUTPUT				PORTD
#define LED_BIT						5

#define BUZZER_PORT_DDR				DDRB
#define BUZZER_PORT_OUTPUT			PORTB
#define BUZZER_BIT					4

#define TUBE_PORT_DDR				DDRD
#define TUBE_PORT_OUTPUT			PORTD
#define TUBE_BIT					3

#include <avr/io.h>
#include <avr/wdt.h>
#include <avr/interrupt.h>
#include <util/delay.h>

#include <avr/pgmspace.h>   // required by usbdrv.h
#include "usbdrv.h"
#include "requests.h"

unsigned int g_counts = 0;

ISR(INT1_vect)
{
	GIMSK &= ~0x80;								// Enable INT1 (tube)
	LED_PORT_OUTPUT |= (1 << LED_BIT);			// Enable LED
	BUZZER_PORT_OUTPUT |= (1 << BUZZER_BIT);	// Buzzer on
	g_counts++;									// Count
	_delay_ms(2);								// Wait
	LED_PORT_OUTPUT &= ~(1 << LED_BIT);			// Disable LED
	BUZZER_PORT_OUTPUT &= ~(1 << BUZZER_BIT);	// Buzzer off
	GIMSK |= 0x80;								// Enable INT1 (tube)
}

usbMsgLen_t usbFunctionSetup(uchar data[8])
{
	usbRequest_t    *rq = (void *)data;
	static uchar    dataBuffer[4];		// Buffer must stay valid when usbFunctionSetup returns
	
    if (rq->bRequest == CUSTOM_RQ_RESET_COUNTS) {
		
		g_counts = 0;
    }
	else if (rq->bRequest == CUSTOM_RQ_GET_COUNTS) {
        
		dataBuffer[0] = g_counts;
		g_counts = 0;
		usbMsgPtr = (usbMsgPtr_t)dataBuffer;
		return 1;
    }
	
    return 0;
}

int main(void)
{
    wdt_disable();
    
    LED_PORT_DDR |= (1 << LED_BIT);						// output
    LED_PORT_OUTPUT &= ~(1 << LED_BIT);					// off
	
	BUZZER_PORT_DDR |= (1 << BUZZER_BIT);				// output
	BUZZER_PORT_OUTPUT &= ~(1 << BUZZER_BIT);			// off
	
	TUBE_PORT_DDR &= ~(1 << TUBE_BIT);					// input
        
	usbInit();
    usbDeviceDisconnect();  // enforce re-enumeration, do this while interrupts are disabled!
    _delay_ms(300);			// fake USB disconnect for > 250 ms
    usbDeviceConnect();
	
	GIMSK |= 0x80;			// Enable INT1 (tube)
	MCUCR |= (0x08 | 0x04);	// Interrupt on rising edge
    sei();					// Enable interrupts
    
	while(1) {        
		usbPoll();		
    }
}