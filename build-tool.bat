@echo off
chcp 65001 >nul
setlocal enabledelayedexpansion

echo Building moroshka-cli as a global tool...

REM Clean previous builds
echo Cleaning previous builds...
dotnet clean
if exist "nupkg" rmdir /s /q "nupkg"

REM Restore dependencies
echo Restoring dependencies...
dotnet restore

REM Build project
echo Building project...
dotnet build --configuration Release

REM Create package
echo Creating package...
dotnet pack --configuration Release --output nupkg

REM Remove previous installation (if exists)
echo Removing previous installation...
dotnet tool uninstall --global moroshka-cli >nul 2>&1

REM Install tool
echo Installing tool...
dotnet tool install --global --add-source ./nupkg moroshka-cli

REM Verify installation
echo Verifying installation...
moroshka --version >nul 2>&1
if %errorlevel% equ 0 (
    echo ✅ moroshka-cli successfully installed!
    echo Use 'moroshka --help' command for help
) else (
    echo ❌ Error during installation verification
)

echo Done!
pause
