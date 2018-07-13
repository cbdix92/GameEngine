@echo off

:: Delete Exeecutable and the libs so compile errors aren't ignored due to an older version being ran. 
del test.exe
del Core.dll
del GameEngine.dll

:: Compile Libs
:: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:library /out:Core.dll Core.cs
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:library /out:GameEngine.dll /r:PresentationCore.dll /r:WindowsBase.dll Animation.cs Background.cs Core.cs Display.cs Events.Cs GameLoop.cs Gameobject.cs Image.cs Input.cs ObjectStateMachine.cs Render.cs Scene.cs Transform.cs Updates.cs 

:: Compile Main
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /r:GameEngine.dll test.cs
test.exe