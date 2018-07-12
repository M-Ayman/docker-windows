# escape=`
FROM microsoft/windowsservercore AS installer
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

ENV UMBRACO_VERSION="7.7.4" `
    UMBRACO_DOWNLOAD_ID="774"

RUN Invoke-WebRequest -UseBasicParsing -OutFile umbraco.zip -Uri "https://our.umbraco.org/contribute/releases/$($env:UMBRACO_DOWNLOAD_ID)?fromdownload=true"; `
    Expand-Archive umbraco.zip -DestinationPath C:\umbraco

# app image
FROM microsoft/aspnet:windowsservercore
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

ENV UMBRACO_VERSION="7.7.4" `
    UMBRACO_ROOT="C:\inetpub\wwwroot\Umbraco"

RUN Remove-Website 'Default Web Site'; `
    New-Item -Path $env:UMBRACO_ROOT -Type Directory -Force; `
    New-Website -Name 'umbraco' -Port 80 -Force -PhysicalPath $env:UMBRACO_ROOT;

COPY --from=installer C:\umbraco ${UMBRACO_ROOT}
COPY docker\umbraco-setup\Set-UmbracoAcl.ps1 C:\
RUN C:\Set-UmbracoAcl.ps1