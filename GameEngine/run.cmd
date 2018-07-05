@echo off

:: Delete Exeecutable and the libs so compile errors aren't ignored due to an older version being ran. 
del test.exe
del RenderCore.dll
del GameEngine.dll

:: Compile Libs
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:library /out:RenderCore.dll RenderCore.cs
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:library /out:GameEngine.dll /r:RenderCore.dll  Render.cs LoopController.cs

:: Compile Main
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /r:GameEngine.dll /r:RenderCore.dll test.cs
test.exe