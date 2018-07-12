# Modernizing .NET Framework Apps with Docker

Source code accompanying the [Pluralsight course](https://www.pluralsight.com/courses/modernizing-dotnet-framework-apps-docker) by [Elton Stoneman](https://www.pluralsight.com/authors/elton-stoneman).

## Webinar Sign Up App

The focus of this module is changing the web application to remove synchronous database calls and replace them with asynchronous event publishing. This shows how you can break up a monolothic app by focusing on features, and splitting components outs into separate Docker containers.

## Pre-requisites

Docker runs on Windows Server 2016 or Windows 10. The minimum version you need for this course is **17.06**. [Docker for Windows](https://www.docker.com/docker-windows) is the easiest way to install Docker.

The code is in Visual Studio 2017 format, but you don't need Visual Studio to build the demo app, that's done with Docker containers.

In the course I use VS Code for working with Dockerfiles, but you can use any text editor.

## Module 3 - Before

The initial state of the app uses synchronous database calls. When you save the web form, the ASP.NET app looks up the related entities and saves the new viewer in the database. This uses a connection from the SQL Server connection pool, and is a bottleneck which stops the application scaling.

## Usage

You can build and run the web app and database from the source code, with no pre-requisites except Docker (you don't need SQL Server or .NET on your machine).

Start from the directory containing this README and build the database and web application images (using the same tags as you see in the module):

```
docker image build --tag webinar-db:v2 --file docker\db\Dockerfile

docker image build --tag webinar-app:v3 --file docker\web\Dockerfile
```

> If this is the first time you've used Docker, the base images for Windows Server Core and SQL Server Express will be downloaded. This takes a while, but Docker caches images so this only happens once.

Then run containers to start the database and the web app:

```
docker container run -d -P --name webinar-db webinar-db:v2

docker container run -d -P --name web-app webinar-app:v3
```

Inspect the web application container and to get the container IP address:

```
docker container inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' web-app
```

Now you can browse to the app and submit the form - data is saved in the SQL Server container.