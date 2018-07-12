# Modernizing .NET Framework Apps with Docker

Source code accompanying the [Pluralsight course](https://www.pluralsight.com/courses/modernizing-dotnet-framework-apps-docker) by [Elton Stoneman](https://www.pluralsight.com/authors/elton-stoneman).

## Webinar Sign Up App

The focus of this module is the SQL Server database used by the web application.

## Pre-requisites

Docker runs on Windows Server 2016 or Windows 10. The minimum version you need for this course is **17.06**. [Docker for Windows](https://www.docker.com/docker-windows) is the easiest way to install Docker.

The code is is Visual Studio 2017 format, but you don't need Visual Studio to build the demo app, that's done with Docker containers.

In the course I use VS Code for working with Dockerfiles.

## Module 2 - After

There are some extra columns in the Viewers table, demonstrating how schema upgrades are packaged in Docker.

There's also a Dockerfile to package the database, using the same approach as Module 1 - a multi-stage Dockerfile that builds the SQL project in the first stage, and packages the generated Dacpac in the second stage.

## Usage

You can build and run the web app and database from this source code, but they're separate components. In Module 3 you'll see how to run the whole solution.