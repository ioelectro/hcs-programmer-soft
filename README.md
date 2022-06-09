# HCS Programmer Software
An open API application for programming HCS301 EEPROM Code Hopping.


![HCS301 Programmer Software](https://user-images.githubusercontent.com/64005694/172905165-ddc48f12-c173-4eb3-8305-408ea8ab3ba6.jpg)

## Description
This software requires an interface hardware that can write information to the IC.The information is sent to the interface IC via the com port using a usb to serial converter.

### Protocol
`UART`,`8 Data`,`1 StopBit`,`No Parity`,`BaudRate 9600`

### Transmit
- Device identification  *(Optional)*
- Information to be programmed


#### Device identification
Immediately after opening the port, the software sends the character `!` and if it does not receive a response, it does so up to three times.<br>
response must send at below format:<br>
`!` `DEVICE-NAME-(STRING)` `\n`

### Receive

