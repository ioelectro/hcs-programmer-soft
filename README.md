# HCS Programmer Software
An open source application for programming HCS301 EEPROM Code Hopping.<br>
Support keeloq key generation from manufacturer code for Simple, Normal and Secure learning algorithm.

![HCS301 Programmer Software](https://user-images.githubusercontent.com/64005694/209923393-3a4efdea-065d-4f8e-99b4-e55fbddbc350.jpg)

## Download
**[Download latest release](https://github.com/ioelectro/hcs-programmer-soft/releases)**

*Required .NET Framework 4.7.2 or Upper.*

## Description
This software requires an interface hardware that can write information to the HCS.The information is sent to the interface via the com port using a usb to serial converter.

### Hardware
Any hardware that supports UART serial communication can be used as an interface and hardware. For example, ARDUINO PIC AVR STM8 are a good choice.

- [Arduino HCS Programmer](https://github.com/ioelectro/arduino-hcs-programmer)

### Protocol
`UART`,`8 Data`,`1 StopBit`,`No Parity`,`BaudRate 9600`

### Transmit
- Device identification  *(Optional)*
- Information to be programmed


#### Device identification
Immediately after opening the port, the software sends the character `!` and if it does not receive a response, it does so up to three times.<br>
response must send at below format:<br>
`!` `DEVICE-NAME-(STRING)` `\n`

#### Information to be programmed
According to the information in the HCS datasheet, 12 WORD 16-bit should be set.<br>
The sending packet contains 25 bytes that are sent as follows:<br>
`>` `WORD0` `WORD1` `WORD2` `WORD3` `WORD4` `WORD5` `WORD6` `WORD7` `WORD8` `WORD9` `WORD10` `WORD11` <br>

Sending this package does not require a response. Instead, the programmer can display the result, error or any message that is described in the following section.

### Receive
The received packages consist of three main sections, which are shown below:<br>
`TYPE-(Char)` `MESSAGE-(STRING)` `\n` <br>

#### Packet TYPE
- Log `<`
- Info `i`
- Warning `w`
- Error `e`

#### Example
Print data to log:<br>
`<` `HELLO` `\n`<br>

Show Warning message:<br>
`w` `Warning!` `\n`<br>




