param (
    $Solution = "$PSScriptRoot/../ManagedSpy.sln",
    $ReleaseDir = "$PSScriptRoot/../releases",
    $Version = '1.2.1',
    $msbuild = 'msbuild'
)

$ErrorActionPreference = 'Stop'

function log($text, $header) {
    if (-not $header) {
        $header = 'build'
    }
    Write-Host "[$header] $text" -ForegroundColor White
}

function exec($command) {
    log "$command $args" 'exec'
    & $command $args
    if (!$?) {
        throw "[build error] $command $args = $LASTEXITCODE"
    }
}

function prepare($platform) {
    exec $msbuild /p:Configuration=Release /p:Platform=$platform '/t:Clean;Rebuild'
    Compress-Archive "$PSScriptRoot/../bin/$platform/Release/*" "$ReleaseDir/ManagedSpy_$($platform)_$Version.zip"
}

if (-not (Test-Path -PathType Container $ReleaseDir)) {
    New-Item -ItemType Directory $ReleaseDir
}

prepare x86
prepare x64
