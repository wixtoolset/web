@setlocal
@set _RELATIVE_OUTPUT_FOLDER=%1

@if "%CONFIGURATION%"=="" set CONFIGURATION=Release
@if "%_RELATIVE_OUTPUT_FOLDER%"=="" set _RELATIVE_OUTPUT_FOLDER=build\deploy

@pushd %~dp0

dotnet publish .\src\Web\Web.csproj --configuration %CONFIGURATION% --output %_RELATIVE_OUTPUT_FOLDER%

@popd
@endlocal
