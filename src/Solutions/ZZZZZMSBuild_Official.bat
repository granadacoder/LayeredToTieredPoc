



REM set __msBuildDir=%WINDIR%\Microsoft.NET\Framework\v2.0.50727
REM set __msBuildDir=%WINDIR%\Microsoft.NET\Framework\v3.5
set __msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
REM set __msBuildDir=C:\Program Files (x86)\MSBuild\12.0\Bin
set __msBuildDir=C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin
set __nugetExe=C:\MyProgFiles\NuGet\v5.3.1\nuget.exe

set __rootDirectory=%~dp0


set __slnName=MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Solution.sln

call "%__nugetExe%" restore "%__slnName%" 


PAUSE


call "%__msBuildDir%\msbuild.exe"  "%__slnName%" /p:Configuration=Debug;FavoriteFood=Popeyes /l:FileLogger,Microsoft.Build.Engine;logfile=ZZZZZMyMsbuildDef_Debug.log
REM call "%__msBuildDir%\msbuild.exe" /target:AllTargetsWrapped "ZZZZZMSBuild.proj" /p:Configuration=Release;FavoriteFood=Popeyes /l:FileLogger,Microsoft.Build.Engine;logfile=ZZZZZMyMsbuildDef_Release.log


set __nugetLocalRepo=
set __nugetOutDirectory=
set __msBuildDir=
set __nugetExe=
set __rootDirectory=
set __slnName=

