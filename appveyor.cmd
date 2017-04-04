@setlocal
@set _P=%~dp0
@if "%CONFIGURATION%"=="" set CONFIGURATION=Debug

@pushd %_P%

dotnet restore Web.sln

dotnet publish .\src\Web\Web.csproj --configuration %CONFIGURATION% --output %_P%build\deploy

@goto :End

Fail:
@exit /b -1

:End
@popd
@endlocal
