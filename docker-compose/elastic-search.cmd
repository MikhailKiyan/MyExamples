@echo off
docker compose -p elastic-search -f elastic-search.yml up -d
if %errorlevel% equ 0 exit
echo Failed with error level: %errorlevel%
