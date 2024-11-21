@echo off
docker compose -p rabbit-mq-server -f rabbit-mq-server.yml up -d
if %errorlevel% equ 0 exit
echo Failed with error level: %errorlevel%
