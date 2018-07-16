@echo off

:: Delete Executable and the libs so compile errors aren't ignored due to an older version being ran. 
del CompilLibs\test.exe
del CompileLibs\GameEngine.dll

:: Compile Libs
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:library /out:CompileLibs\GameEngine.dll /r:CompileLibs\PresentationCore.dll /r:CompileLibs\WindowsBase.dll Animation.cs Background.cs Core.cs Display.cs Events.Cs GameLoop.cs Gameobject.cs Image.cs Input.cs ObjectStateMachine.cs Render.cs Scene.cs Transform.cs Updates.cs 

:: Compile Main
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /out:CompileLibs\test.exe /r:CompileLibs\GameEngine.dll test.cs
CompileLibs\test.exe