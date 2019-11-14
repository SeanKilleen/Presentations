# The Neo4j WebAPI Template

## What This Template Gives You

* **A Docker Compose File:** This will allow you to run `docker-compose up` and run the graph database and the WebAPI connected to it.
* **A Neo4j Instance:** A containerized instance of a neo4j graph DB. You can access it at the port that you choose (default `7474`) 
* **A .NET Core WebAPI connected to Neo4j**: The WebAPI is in its own container, and you can access it at a port you choose (default `5000`)
* **Sample Data**: The neo4j db will be seeded with a small amount of data to enable the example query.
* **A Sample API request to Query the DB**: The WebAPI project contains a Neo4j library and a sample API endpoint that does a query against the containerized neo4j instance.
* **An xUnit test project for the API**: An xUnit project is included that has an integration test for the query against neo4j.

## Prerequisites

This template assumes you have the following:

* .NET Core (you'll need this to run the `dotnet new` command)
* Docker (you'll need this to spin up the docker images)

## How to Install

### Via Nuget

Coming soon.

### Via file

* Clone or download this repo
* Run `dotnet new -i [path to the repo files]`

For example, if you downloaded the repo contents to C:\MyStuff, you'd run `dotnet new -i C:\MyStuff`.

## How to Use

* Run `dotnet new neo4jwebapi`

### Parameters

* Run `dotnet new neo4jwebapi --help` to see a list of parameters and their descriptions.
