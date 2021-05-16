@setlocal
@set _RELATIVE_OUTPUT_FOLDER=%1

@if "%CONFIGURATION%"=="" set CONFIGURATION=Release
@if "%_RELATIVE_OUTPUT_FOLDER%"=="" set _RELATIVE_OUTPUT_FOLDER=build\deploy

@pushd %~dp0

:: build and test tools

dotnet test -c %CONFIGURATION% src\test\XsdToMarkdownTests\XsdToMarkdownTests.csproj

:: build reference markdown from xsds into site

build\%CONFIGURATION%\netcoreapp3.1\XsdToMarkdown.exe -out src\Site\documents\documentation\manual\v4\reference src\xsd4\*.xsd || exit /b

:: publish web site

dotnet publish .\src\Web\Web.csproj --configuration %CONFIGURATION% --output %_RELATIVE_OUTPUT_FOLDER%

@popd
@endlocal
