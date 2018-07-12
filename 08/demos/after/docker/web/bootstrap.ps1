Write-Output 'Bootstrap starting'

# copy process-level environment variables (from `docker run`) machine-wide
foreach($key in [System.Environment]::GetEnvironmentVariables('Process').Keys) {
    if ([System.Environment]::GetEnvironmentVariable($key, 'Machine') -eq $null) {
        $value = [System.Environment]::GetEnvironmentVariable($key, 'Process')
        [System.Environment]::SetEnvironmentVariable($key, $value, 'Machine')
        Write-Output "Set environment variable: $key"
    }
}

if (Test-Path $env:CONNECTION_STRINGS_PATH) {
    
    Remove-Item -Force -Path C:\web-app\connection-strings.config
    
    New-Item -Path C:\web-app\connection-strings.config `
             -ItemType SymbolicLink `
             -Value $env:CONNECTION_STRINGS_PATH

    Write-Verbose "INFO: Using connection string from secret"
}
else {
    Write-Verbose "WARN: Using default connection strings, secret file not found at: $env:CONNECTION_STRINGS_PATH"
}

Write-Output 'Starting IIS'
Start-Service W3SVC

Write-Output 'Sending warm-up request'
Invoke-WebRequest http://localhost/app -UseBasicParsing | Out-Null

Write-Output 'Starting metrics exporter'
Start-Process -NoNewWindow C:\aspnet-exporter\aspnet-exporter.exe

Write-Output 'Running ServiceMonitor'
& C:\ServiceMonitor.exe w3svc