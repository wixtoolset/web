@setlocal
@pushd %~dp0

@rd /s/q "..\build" 2> nul
@rd /s/q "Docusaurus\docs\reference\schema" 2> nul
@rd /s/q "Docusaurus\docs\reference\api" 2> nul
@rd /s/q "Web\wwwroot" 2> nul

@popd
@endlocal
