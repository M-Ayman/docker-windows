# Modernizing .NET Framework Apps with Docker

Source code accompanying the [Pluralsight course](https://www.pluralsight.com/courses/modernizing-dotnet-framework-apps-docker) by [Elton Stoneman](https://www.pluralsight.com/authors/elton-stoneman).

## Webinar Sign Up App

The focus of this module is changing the web application to remove synchronous database calls and replace them with asynchronous event publishing. This shows how you can break up a monolothic app by focusing on features, and splitting components outs into separate Docker containers.

## Pre-requisites

Docker runs on Windows Server 2016 or Windows 10. The minimum version you need for this course is **17.06**. [Docker for Windows](https://www.docker.com/docker-windows) is the easiest way to install Docker.

The code is in Visual Studio 2017 format, but you don't need Visual Studio to build the demo app, that's done with Docker containers.

In the course I use VS Code for working with Dockerfiles, but you can use any text editor.

## Module 7 -Before

The initial state of the app runs in Docker Compose. The image names in the source use the author's Docker Hub repositories, so you can run the application from the exact same images used in the course.

## Usage

You can build and run the whole solution from the source code, with no pre-requisites except Docker. Umbraco and Grafana have seperate setup steps, but you can pull the images from the author's Docker Hub repositories.

From this directory, run `docker-compose pull` to download all the images:

```
docker-compose pull
```

Run the application using Docker Compose:

```
docker-compose up -d
```

Now you can browse to the swarm - the homepage is served from the CMS, and the rest of the app is served from the original webinar app.