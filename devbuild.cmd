@echo off

setlocal
pushd %~dp0

:parse_args
if /i "%1"=="release" set _C=Release
if /i "%1"=="inc" set _INCREMENTAL=1
if /i "%1"=="clean" set _INCREMENTAL= & set _CLEAN=1
if /i "%1"=="run" set _RUN=1
if not "%1"=="" shift & goto parse_args

if not "%_INCREMENTAL%"=="1" call src\clean.cmd
if not "%_CLEAN%"=="" goto end

if not exist src\Docusaurus\node_modules call src\restore.cmd

call src\build.cmd %_C%

if NOT "%_RUN%"=="1" goto end

pushd src\Docusaurus
set DOCUSAURUS_SSR_CONCURRENCY=5
npm run start
popd

:end
popd
endlocal
