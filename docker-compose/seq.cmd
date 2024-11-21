@echo off
docker compose -p seq -f seq.yml up -d
if %errorlevel% equ 0 exit
echo Failed with error level: %errorlevel%
