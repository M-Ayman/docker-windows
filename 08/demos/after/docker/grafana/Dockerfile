# escape=`
FROM microsoft/windowsservercore AS installer
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

ENV GRAFANA_VERSION="4.6.1"

RUN Invoke-WebRequest "https://s3-us-west-2.amazonaws.com/grafana-releases/release/grafana-$($env:GRAFANA_VERSION).windows-x64.zip"  -OutFile grafana.zip -UseBasicParsing; `
    Expand-Archive grafana.zip -DestinationPath C:\; `
    Move-Item "grafana-$($env:GRAFANA_VERSION)" grafana

# Grafana
FROM microsoft/nanoserver:10.0.14393.1884

EXPOSE 3000
WORKDIR C:\grafana\bin
CMD ["grafana-server.exe"]

COPY --from=installer C:\grafana C:\grafana