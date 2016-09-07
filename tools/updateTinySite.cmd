@echo off
if "%1"=="" goto Syntax
set _P=%~dp0

rd /s /q %TMP%\~ts
nuget install -Version %1 -OutputDirectory %TMP%\~ts -Source https://api.nuget.org/v3/index.json tinySite

rd /s /q %_P%tinySite
md %_P%tinySite
copy %TMP%\~ts\tinysite.%1\tools\* %_P%\tinySite

rd /s /q %TMP%\~ts
goto :EOF

:Syntax
echo Must provide a version for tinySite.
echo.
nuget list tinysite -AllVersions -Source https://api.nuget.org/v3/index.json