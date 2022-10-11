@setlocal
@pushd %~dp0

@rd /s/q "..\build" 2> nul
@rd /s/q "Docusaurus\docs\reference" 2> nul
@rd /s/q "Web\wwwroot" 2> nul

@popd
@endlocal
