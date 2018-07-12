# escape=`
FROM microsoft/windowsservercore AS installer
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

ENV KIBANA_VERSION="5.6.2" `
    KIBANA_SHA512="e41434e12202bf58c89bfb24e7b40ba340ef513a1c2f3b6d2a34f656287684e0c2da4247588a88f0343bacc8646b1198fb968c9366ded06ddd73d2c20f4e902c"

RUN Invoke-WebRequest -OutFile kibana.zip "https://artifacts.elastic.co/downloads/kibana/kibana-$($env:KIBANA_VERSION)-windows-x86.zip" -UseBasicParsing; `
    if ((Get-FileHash kibana.zip -Algorithm sha512).Hash -ne $env:KIBANA_SHA512) {exit 1} ; `
    Expand-Archive kibana.zip -DestinationPath C:\ ; `
    Move-Item c:\kibana-$($env:KIBANA_VERSION)-windows-x86 C:\kibana

# Kibana
FROM microsoft/windowsservercore
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

EXPOSE 5601
WORKDIR C:\kibana
CMD ".\bin\kibana.bat"

COPY --from=installer C:\kibana\ .

RUN (Get-Content ./config/kibana.yml) `
      -replace '#server.host: \"localhost\"', 'server.host: \"0.0.0.0\"' `
      -replace '#elasticsearch.url: \"http://localhost:9200\"', 'elasticsearch.url: \"http://elasticsearch:9200\"' `
    | Set-Content ./config/kibana.yml