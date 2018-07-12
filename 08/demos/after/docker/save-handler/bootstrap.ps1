Write-Output 'Bootstrap starting'

if (Test-Path $env:CONNECTION_STRINGS_PATH) {

    Remove-Item -Force -Path C:\save-prospect\connection-strings.config
    
    New-Item -Path C:\save-prospect\connection-strings.config `
             -ItemType SymbolicLink `
             -Value $env:CONNECTION_STRINGS_PATH
         
    Write-Verbose "INFO: Using connection string from secret"
}
else {
    Write-Verbose "WARN: Using default connection strings, secret file not found at: $env:CONNECTION_STRINGS_PATH"
}

Write-Output 'Running SaveProspect'
& .\SignUp.MessageHandlers.SaveProspect.exe