@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)

call %nuget% restore EmmaSharp\packages.config -OutputDirectory %cd%\packages -NonInteractive

"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" EmmaSharp.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false /p:BuildInParallel=true /p:RestorePackages=true /t:Clean,Rebuild

mkdir build
mkdir build\lib
mkdir build\lib\net46

%nuget% pack "EmmaSharp\EmmaSharp.csproj" -IncludeReferencedProjects -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"