# escape=`
FROM sixeyed/msbuild:netfx-4.5.2-webdeploy AS builder

WORKDIR C:\src\SignUp.Web
COPY src\SignUp.Web\packages.config .
RUN nuget restore packages.config -PackagesDirectory ..\packages

COPY src\ C:\src
RUN msbuild SignUp.Web.csproj /p:OutputPath=c:\out `
        /p:DeployOnBuild=true /p:VSToolsPath=C:\MSBuild.Microsoft.VisualStudio.Web.targets.14.0.0.3\tools\VSToolsPath

# app image
FROM microsoft/aspnet:windowsservercore
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop';"]

ENV MESSAGE_QUEUE_URL="nats://message-queue:4222"

WORKDIR C:\web-app
RUN Remove-Website -Name 'Default Web Site';`
    New-Website -Name 'web-app' -Port 80 -PhysicalPath 'C:\web-app'; `
    New-WebApplication -Name 'app' -Site 'web-app' -PhysicalPath 'C:\web-app'

COPY --from=builder C:\out\_PublishedWebsites\SignUp.Web C:\web-app