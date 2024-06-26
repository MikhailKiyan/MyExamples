@echo off
docker compose -p nginx -f nginx.yml up -d
if %errorlevel% equ 0 exit
echo Failed with error level: %errorlevel%
