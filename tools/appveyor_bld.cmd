@setlocal

@set _P=%~dp0..\
@set _RELATIVE_OUTPUT_FOLDER=%1

@if "%CONFIGURATION%"=="" set CONFIGURATION=Release
@if "%_RELATIVE_OUTPUT_FOLDER%"=="" set _RELATIVE_OUTPUT_FOLDER=build\deploy

@pushd %_P%

dotnet restore Web.sln

dotnet publish .\src\Web\Web.csproj --configuration %CONFIGURATION% --output %CD%\%_RELATIVE_OUTPUT_FOLDER%

@popd
@endlocal
