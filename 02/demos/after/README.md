# Modernizing .NET Framework Apps with Docker

Source code accompanying the [Pluralsight course](https://www.pluralsight.com/courses/modernizing-dotnet-framework-apps-docker) by [Elton Stoneman](https://www.pluralsight.com/authors/elton-stoneman).

## Webinar Sign Up

An ASP.NET 4.5 WebForms app used for demonstrating Docker containers on Windows. 

## Pre-requisites

Docker runs on Windows Server 2016 or Windows 10. The minimum version you need for this course is **17.06**. [Docker for Windows](https://www.docker.com/docker-windows) is the easiest way to install Docker.

The code is is Visual Studio 2017 format, but you don't need Visual Studio to build the demo app, that's done with Docker containers.

In the course I use VS Code for working with Dockerfiles.

## Module 1 - After

The code is unchanged, but there are two approaches shown for running the app in Docker:

- packaging the existing MSI
- compiling and packaging the app from source.

## Usage

To run the app you will need a SQL database to connect to - that's covered in Module 2.