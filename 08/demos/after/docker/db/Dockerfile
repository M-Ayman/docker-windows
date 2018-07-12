# escape=`
FROM sixeyed/msbuild:netfx-4.5.2-ssdt AS builder

WORKDIR C:\src\SignUp.Database
COPY src\SignUp.Database .
RUN msbuild SignUp.Database.sqlproj `
    /p:SQLDBExtensionsRefPath="C:\Microsoft.Data.Tools.Msbuild.10.0.61026\lib\net40" `
    /p:SqlServerRedistPath="C:\Microsoft.Data.Tools.Msbuild.10.0.61026\lib\net40"

# db image
FROM microsoft/mssql-server-windows-express:2016-sp1-windowsservercore-10.0.14393.1715

ENV ACCEPT_EULA="Y" `
    DATA_PATH="C:\data" `
    sa_password="DockerCon!!!"

VOLUME ${DATA_PATH}
WORKDIR C:\init

COPY docker\db\Initialize-Database.ps1 .
CMD powershell ./Initialize-Database.ps1 -sa_password $env:sa_password -data_path $env:data_path -Verbose

COPY --from=builder C:\src\SignUp.Database\bin\Debug\SignUp.Database.dacpac .