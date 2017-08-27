# phone-book-search-net

[![Build Status](https://travis-ci.org/gustavodido/phone-book-search-net.svg?branch=master)](https://travis-ci.org/gustavodido/phone-book-search-net)

1. Bootstrap the application

Create solution
	dotnet new sln

Create the react project

move gitignore to source
dotnet new react -- force
npm install


Templates
dotnet new --install Microsoft.AspNetCore.SpaTemplates::*


brew install postgresql

docker run --name phone-book-search-postgres -p 8092:5432 -e POSTGRES_DB=phone-book-search -e POSTGRES_USER=phone-book-search -e POSTGRES_PASSWORD=phone-book-search --rm -d postgres

dotnet add [Project] package FakeItEasy
dotnet add WebApp.csproj package Npgsql
dotnet add WebApp.csproj package Dapper

User ID=damienbod;Password=1234;Host=localhost;Port=5432;Database=damienbod;Pooling=true;

ASPNETCORE_ENVIRONMENT

    "Evolve.ConnectionString": "User ID=phone-book-search;Password=phone-book-search;Host=localhost;Port=8092;Database=phone-book-search;Pooling=true;",
    "Evolve.Driver": "npgsql",
    "Evolve.Locations": "Sql_Scripts",
