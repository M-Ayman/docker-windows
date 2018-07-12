# Modernizing .NET Framework Apps with Docker

Source code accompanying the [Pluralsight course](https://www.pluralsight.com/courses/modernizing-dotnet-framework-apps-docker) by [Elton Stoneman](https://www.pluralsight.com/authors/elton-stoneman).

## Webinar Sign Up App

The focus of this module is using Docker Compose to deploy and manage the application, and adding monitoring to the custom .NET components. You seen Prometheus being used to capture metrics, which are displayed in a custom dashboard using Grafana.

## Pre-requisites

Docker runs on Windows Server 2016 or Windows 10. The minimum version you need for this course is **17.06**. [Docker for Windows](https://www.docker.com/docker-windows) is the easiest way to install Docker.

The code is in Visual Studio 2017 format, but you don't need Visual Studio to build the demo app, that's done with Docker containers.

In the course I use VS Code for working with Dockerfiles, but you can use any text editor.

## Module 6 - Before 

The module starts with PowerShell scripts to build and run the application, and with no monitoring for any of the components. You can run it from this directory, and it will have the same behaviour as the end of Module 5. 

## Usage

You can build and run the whole solution from the source code, with no pre-requisites except Docker (you don't need Umbraco or Nginx on your machine). Umbraco has its own setup requirements which mean you need to manually configure the image, to build `umbraco:v1`. You see how to do this in Module 5.

Start from the directory containing this README and build all the Docker images - the script uses the same tags as you see in the module:

```
./build.ps1
```

If you have any containers running from previous modules, remove themn all:

```
docker container rm --force $(docker container ls --quiet --all)
```

Then run the script to start containers for the whole solution:

```
./run.ps1
```

Inspect the proxy container and to get the container IP address:

```
docker container inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' nginx
```

Now you can browse to the proxy - the homepage is served from the CMS, and the rest of the app is served from the original webinar app.