# Modernizing .NET Framework Apps with Docker

Source code accompanying the [Pluralsight course](https://www.pluralsight.com/courses/modernizing-dotnet-framework-apps-docker) by [Elton Stoneman](https://www.pluralsight.com/authors/elton-stoneman).

## Webinar Sign Up App

The focus of this module is using Docker Compose to deploy and manage the application, and adding monitoring to the custom .NET components. You seen Prometheus being used to capture metrics, which are displayed in a custom dashboard using Grafana.

## Pre-requisites

Docker runs on Windows Server 2016 or Windows 10. The minimum version you need for this course is **17.06**. [Docker for Windows](https://www.docker.com/docker-windows) is the easiest way to install Docker.

The code is in Visual Studio 2017 format, but you don't need Visual Studio to build the demo app, that's done with Docker containers.

In the course I use VS Code for working with Dockerfiles, but you can use any text editor.

## Module 6 - After 

At the end of the module there is a Docker Compose file to describe the application, and a second compose file which adds configuration to build the images. The source code has been extended to add monitoring to the custom .NET components, and the Compose file includes Prometheus and Grafaan to store and display metrics. 

## Usage

Grafana and Umbraco have custom setup requirements which mean you need to manually configure the images. You see how to configure Umbraco in Module 5 and Grafana in Module 6. The rest of the solution can be built and run using Docker Compose.

Start from the directory containing this README and build all the Docker images - the compose file uses the same tags as you see in the module:

```
docker-compose -f docker-compose.yml -f docker-compose.build.yml build
```

If you have any containers running from previous modules, remove themn all:

```
docker container rm --force $(docker container ls --quiet --all)
```

Then run Docker Compose to start containers for the whole solution:

```
docker-compose up -d
```

Inspect the proxy container  to get the container IP address:

```
docker container inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' after_nginx_1
```

Now you can browse to the proxy - the homepage is served from the CMS, and the rest of the app is served from the original webinar app. Metrics for the web app and the message handlers are collected by Prometheus, and you can view them in Grafana.