# Modernizing .NET Framework Apps with Docker

Source code accompanying the [Pluralsight course](https://www.pluralsight.com/courses/modernizing-dotnet-framework-apps-docker) by [Elton Stoneman](https://www.pluralsight.com/authors/elton-stoneman).

## Webinar Sign Up App

The focus of this module is changing the web application to remove synchronous database calls and replace them with asynchronous event publishing. This shows how you can break up a monolothic app by focusing on features, and splitting components outs into separate Docker containers.

## Pre-requisites

Docker runs on Windows Server 2016 or Windows 10. The minimum version you need for this course is **17.06**. [Docker for Windows](https://www.docker.com/docker-windows) is the easiest way to install Docker.

The code is in Visual Studio 2017 format, but you don't need Visual Studio to build the demo app, that's done with Docker containers.

In the course I use VS Code for working with Dockerfiles, but you can use any text editor.

## Module 5 - After

The final state of the app uses a web proxy as the entrypoint, which routes homepage requests to the CMS and all other requests to the original ASP.NET app. The proxy is also configured to support GZip, client-side caching for images, and server-side caching for proxied content.

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