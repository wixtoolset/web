@setlocal
@pushd %~dp0

@set _C=Debug
@set _L=%~dp0..\build\logs

:parse_args
@if /i "%1"=="release" set _C=Release
@if not "%1"=="" shift & goto parse_args

@echo Building web %_C%

:: Build and test tools

dotnet test test\XsdToMarkdownTests\XsdToMarkdownTests.csproj -c %_C% -nologo -m -warnaserror -bl:%_L%\build.binlog || exit /b

:: Build reference markdown from xsds into site

:: ..\build\%_C%\net6.0\XsdToMarkdown.exe -out Docusaurus\docs\reference xsd4\*.xsd || exit /b

:: Publish dynamic web site

dotnet publish Web\Web.csproj -c %_C% --output ..\build\deploy -nologo -m -warnaserror -bl:%_L%\publish.binlog || exit /b

:: Build static web site

call npm --prefix Docusaurus run build -- --out-dir ..\..\build\deploy\wwwroot || exit /b

@popd
@endlocal
