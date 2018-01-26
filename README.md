DesktopAppAutomation - A simple Console app in .Net to automate desktop application by only modifying the config file.
========================================

Release Notes
-------------

[Located at github.com/koder101/DesktopAppAutomation](https://github.com/koder101/DesktopAppAutomation/)

Features
--------
- DesktopAppAutomation is an automation app that you can use to automate simple to moderate complexity repeated tasks.
- This tool is made using the available [Winium.Cruciatus library at github.com/2gis/Winium.Cruciatus](https://github.com/2gis/Winium.Cruciatus/)

Very Quick Start
--------
1. Clone the project to your local.
2. Build it in Release mode.
3. Use the 'Inspect.exe' to find the automation control id of the application you want.
4. Configure the config file as shown below :

```cfg
<ActionSequence>
    <Actions>
      <add key="ExecutablePath1" value="C:/windows/system32/notepad.exe"/>  
      <add key="Wait0" value="2"/>
      <add key="WinFinder1" value="Untitled - Notepad"/>
      <add key="SetFocus1" value="15"/>   <!-- Id of the Notepad editor area. -->
      
          <!-- In SetText operation ';#' acts as a separator between the control id and the text. -->
      <add key="SetText1" value="15;#This demo will open calculator and do some automated operations."/>
      
      <add key="Wait1" value="2"/>
      <add key="ExecutablePath2" value="C:/windows/system32/calc.exe"/>  
      <add key="Wait2" value="2"/>      
      <add key="WinFinder2" value="Calculator"/> 
      <!-- Auomation ID For below Windows 10 -->
      <add key="FindElementByUid2" value="134"></add>   <!-- Id for button 4 -->
      <add key="Wait3" value="1"/>
      <add key="FindElementByUid3" value="92"></add>    <!-- Id for button * -->
      <add key="Wait4" value="1"/>
      <add key="FindElementByUid4" value="136"></add>   <!-- Id for button 6 -->
      <add key="Wait5" value="1"/>
      <add key="FindElementByUid5" value="121"></add>   <!-- Id for button = -->
      
      
      <!-- Auomation ID For Windows 10, uncomment these if you are using Windows 10 and comment the above Ids -->
      <!-- <add key="FindElementByUid2" value="num4Button"></add>
      <add key="Wait2" value="1"/>
      <add key="FindElementByUid3" value="multiplyButton"></add>
      <add key="Wait3" value="1"/>
      <add key="FindElementByUid4" value="num6Button"></add>
      <add key="Wait4" value="1"/>
      <add key="FindElementByUid5" value="equalButton"></add> -->
    </Actions>
  </ActionSequence>
```

5. Run the ConsoleApplication and watch the magic happening.


Important Convention Note:
--------
1. There are eight different kinds of controls avilable.
2. For any control appearing more than onnce in the config file, should be suffixed with incremental number.
   For Example: In the config shown above observe the suffixed interger for 'Wait' as 'Wait0', Wait1', ... 'Wait5'.
3. Follow the same convention for all other controls.




