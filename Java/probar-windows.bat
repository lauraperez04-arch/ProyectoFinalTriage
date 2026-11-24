@echo off
cd /d "%~dp0"
if not exist out mkdir out
javac -encoding UTF-8 -d out src\triaje\*.java
if errorlevel 1 exit /b 1
java -Dfile.encoding=UTF-8 -cp out triaje.PruebasArbol
