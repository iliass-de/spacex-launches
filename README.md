# spacex-launches
This is about a web application based on VueJs 3 and ASP.Net Core 6 Stack.
The Server takes it source of information from the web Api https://docs.spacexdata.com

## Table of Content
1. [System requirements](#Systemrequirements)
2. [Project setup](#Projectsetup)
3. [Api tests](#Apitests)

## System requirements
* Asp.Net Core 6 runtime
* NodeJs 14.x

## Project setup
Clone the project with the command:
```
git clone https://github.com/iliass-de/spacex-launches.git
```
### Server

Switch to './server/launchApi' folder and run:
```
dotnet run
```

### Client


Switch to client folder and run:
```
npm install  
npm run serve
```
Access the application over http://localhost:8080/ 

## Api tests
The api tests have been written with Postman as collection. These Tests are executed in github action with newman service. For further information, see the "launchActions.yml" file.
