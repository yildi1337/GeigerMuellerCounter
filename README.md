# Geiger Mueller Counter
A simple Geiger–Mueller Counter for the Detection of Ionizing Radiation

<p align="center">
  <img src="https://github.com/yildi1337/GeigerMuellerCounter/blob/main/pictures/device_closed.jpg" />
</p>

<p align="center">
  <img src="https://github.com/yildi1337/GeigerMuellerCounter/blob/main/pictures/device_inside.jpg" />
</p>

# Schematics
Please see subdirectory *schematics*.

# Controller Board
The *Controller Board* contains an 8-bit [ATtiny2313](https://www.microchip.com/wwwproducts/en/ATtiny2313) microcontroller from Atmel (nowadays Microchip) and a buzzer. For counting, the output of the *Tube Board* is connected to one of the microcontroller's external interrupt pins. In addition, the microcontroller is equipped with a USB interface.

<p align="center">
  <img src="https://github.com/yildi1337/GeigerMuellerCounter/blob/main/pictures/controller_board.jpg" />
</p>

# High-Voltage Board
The *High-Voltage Board* contains a DC/DC converter to generate the 400 V operating voltage for the tube by means of an [MC34063A](https://www.ti.com/product/MC34063A) switching regulator.

<p align="center">
  <img src="https://github.com/yildi1337/GeigerMuellerCounter/blob/main/pictures/high_voltage_board.jpg" />
</p>

# Tube Board
The *Tube Board* simply connects the tube (Si-39G) itself and generates the 5 V pulses for the *Controller Board*.

<p align="center">
  <img src="https://github.com/yildi1337/GeigerMuellerCounter/blob/main/pictures/tube_board.jpg" />
</p>

# Software
The overall Geiger-Mueller Counter is based on three software parts. The firmware (subdirectory *firmware*) runs on the microcontroller. It counts and communicates with the computer via USB. A command line tool (subdirectory *usb_command*) handles the USB communication on the computer side. Both parts of software are mainly based on the [V-USB library](https://www.obdev.at/products/vusb/index.html). An additional graphical user interface (subdirectory *gui*) written in C# executes the command line tool (usb_command.exe) every second and plots the counts per second. This GUI application utilizes the [ZedGraph](https://sourceforge.net/projects/zedgraph/) library for plotting the data.

<p align="center">
  <img src="https://github.com/yildi1337/GeigerMuellerCounter/blob/main/pictures/screenshot_gui.jpg" />
</p>

# Demonstration Video
For the demonstration video a slightly radioactive metaautunite/uranocircite has been used.
<p align="center">
  <img src="https://github.com/yildi1337/GeigerMuellerCounter/blob/main/pictures/metaautunite-uranocircite.jpg" />
</p>

<p align="center">
    <a href="https://www.youtube.com/watch?v=izTdFRx8trE" title="Geiger-Mueller Counter Test with Metaautunite/Uranocircite"><img src="http://img.youtube.com/vi/izTdFRx8trE/0.jpg" /></a>
</p>
