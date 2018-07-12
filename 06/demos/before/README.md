# Modernizing .NET Framework Apps with Docker

Source code accompanying the [Pluralsight course](https://www.pluralsight.com/courses/modernizing-dotnet-framework-apps-docker) by [Elton Stoneman](https://www.pluralsight.com/authors/elton-stoneman).

## Webinar Sign Up App

The focus of this module is changing the web application to remove synchronous database calls and replace them with asynchronous event publishing. This shows how you can break up a monolothic app by focusing on features, and splitting components outs into separate Docker containers.

## Pre-requisites

Docker runs on Windows Server 2016 or Windows 10. The minimum version you need for this course is **17.06**. [Docker for Windows](https://www.docker.com/docker-windows) is the easiest way to install Docker.

The code is in Visual Studio 2017 format, but you don't need Visual Studio to build the demo app, that's done with Docker containers.

In the course I use VS Code for working with Dockerfiles, but you can use any text editor.

## Module 5 - Before

The final state of the app uses event publishing. The web app publishes an event to a message queue when a viewer signs up, and a message handler picks up that event and makes the database calls. This architecture scales, because you can run many web application containers and if user load is high the events are stored in the message queue until the handler processes them.

## Usage

You can build and run the web app and database from the source code, with no pre-requisites except Docker (you don't need SQL Server or .NET on your machine).

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

Inspect the web application container and to get the container IP address:

```
docker container inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' web-app
```

Now you can browse to the app and submit the form - events are handled by the message handler, data is saved in the SQL Server container and in Elasticsearch.

You can see the Elasticsearch data in Kibana:

```
docker container inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' kibana
```

You can browse to Kibana, connect to the 'viewers' index, and see the data saved in Elasticsearch.