@echo off
docker compose -p ms-sql-server -f ms-sql-server.yml up -d
if %errorlevel% equ 0 exit
echo Failed with error level: %errorlevel%
