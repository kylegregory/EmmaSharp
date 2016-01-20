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

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild EmmaSharp.sln /p:Configuration=Release /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false /p:BuildInParallel=true /p:RestorePackages=true /t:Clean,Rebuild

mkdir build
mkdir build\lib
mkdir build\lib\net45

%nuget% pack "EmmaSharp.nuspec" -IncludeReferencedProjects -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"