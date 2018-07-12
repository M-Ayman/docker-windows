FROM microsoft/aspnet:windowsservercore

COPY output/SignUp.msi .

RUN powershell Start-Process .\SignUp.msi -Wait 