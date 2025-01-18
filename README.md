# CareerMaintenanceFS2024


A One Button Click solution that executes the career maintenance of all your planes in FS2024
-


![GUIPicture](https://github.com/user-attachments/assets/37b90705-88fc-40e6-b445-bae94bd0c90d)


It will work for Screens with a 16:9 ratio resolution: (3840x2160)(1920x1080)

It may or may not work with resolutions not 16:9.
As a rule as more extrem your screen ratio derivates from 16:9 as more likely it will fail to work.

It can work with FS2024 in windows mode if you don't resize the window and the full window is visible.


Installation:
--------------
 Just copy the exe anywhere you like. It is the program itself and directly executeable.

  
How to use it:
--------------

 1) Execute CareerMaintenane and Execute FS2024
    the order is not important

 2) Navigate to the All Companies Screen

 3) Alt-TAB and change to the CareerMaintenance Window

 4) Press the big Green Start Button

 *** Then hands away !!! ***
 --

 Do not move the mouse or do anything but wait.

If the Execution stops in mid run due to UI troubles. First wait a minute there exists recovery loops.
If it stays stuck navigate back to the All Companies Screen then ALT-TAB and press Green START Button again.
The program will continue from the point where it was interrupted.

In case you want to start the maintenance from the very beginning just press the Reset Button.

The STOP Button would work in theorie in practice you can't use it because when the srcipt is running and you do an ALT-TAB
the focus and the keys go elsewhere on the Desktop.

Best way to stop so far is to press "ESC" wait till it tries the recover and then press "ESC" again.


 The Program does this:
 -

 - It moves the mouse out of the way to the top left corner of the screen (0,0);
 - It brings FS2024 to the front and gives it the focus
 - It puts keys into the keyboardbuffer that goes to the focused application which hopefully should be and stay FS2024
 - It does small partial ScreenShots of 21x21 pixel on certain locations on which it evaluates the center pixel color 
   to help it navigate the menus and wait for certain key executions

Now this isn't the safest way to control an UI but there is only a single AutomationElement which does not allow to control
the app in a normal and safe way.
 
