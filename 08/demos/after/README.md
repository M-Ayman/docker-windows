# Modernizing .NET Framework Apps with Docker

Source code accompanying the [Pluralsight course](https://www.pluralsight.com/courses/modernizing-dotnet-framework-apps-docker) by [Elton Stoneman](https://www.pluralsight.com/authors/elton-stoneman).

## Webinar Sign Up App

The focus of this module is getting the application ready for a production deployment. The Dockerfiles are all built from specific image versions, the application images are built with support for Docker secrets, and the Docker Compose files are split into different files for production and non-production environments.

## Pre-requisites

Docker runs on Windows Server 2016 or Windows 10. The minimum version you need for this course is **17.06**. [Docker for Windows](https://www.docker.com/docker-windows) is the easiest way to install Docker.

The code is in Visual Studio 2017 format, but you don't need Visual Studio to build the demo app, that's done with Docker containers.

In the course I use VS Code for working with Dockerfiles, but you can use any text editor.

## Module 7 - After

The final state of the app runs in Docker swarm mode, which provides high availability, security and a robust platform for production support.

## Usage

You can build and run the whole solution from the source code, with no pre-requisites except Docker. Umbraco and Grafana have seperate setup steps, but you can pull the images from the author's Docker Hub repositories.

From this directory, run `docker-compose pull` to download all the images:

```
docker-compose `
 -f docker-compose.yml ` 
 -f docker-compose-test.yml `
 pull
```

If you're running on a single server (or using Docker for Windows), not in swarm mode, run the application using Docker Compose:

```
./run.ps1
```

If you're running in swarm mode, you will need to create a secret named `webinar-connection-strings` containing your database connection string. Then use Docker Compose to merge the input files:

```
docker-compose `
 -f docker-compose.yml ` 
 -f docker-compose-prod.yml `
 config > docker-stack.yml
```

And then deploy the stack to the swarm:

```
docker stack deploy -c docker-stack.yml webinar
```

Now you can browse to the swarm - the homepage is served from the CMS, and the rest of the app is served from the original webinar app.