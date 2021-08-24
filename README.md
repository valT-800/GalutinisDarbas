# RestfulMovies
A simple RESTful web application which we created to learn the basics of creating RESTful web application in ASP.NET Core framework.

![image](https://user-images.githubusercontent.com/50613873/84821246-7d415900-b023-11ea-819f-c07f7271a73a.png)

## Table of Contents
* [Team Members](#team-members)
* [Installation](#installation)
* [Tech/framework used](#techframework-used)
* [Database used](#database-used)

## Team Members
* Tomas Stanislovėnas - dev
* Gediminas Alšauskas - dev
* Karolina Glodenytė - dev

## Installation
To run our project, first you need to open it with Visual Studio. Second step would be to run the project as IIS Express, by doing that RESTful web service will open in your browser.

## Tech/framework used
* **Language**: C#
* **IDE(integrated development environment)**: Visual Studio
* **Framework**: ASP.NET Core
* **DBMS(database management system)**: Microsoft Azure

## Database used
The database of our project consists of 3 database tables  
**Movie**:
```
CREATE TABLE Movie
(
    ID INT IDENTITY PRIMARY KEY Not NULL,
    [Name] VARCHAR(128) Default NULL,
    Genre VARCHAR(128) Default NULL,
    Length VARCHAR(128) Default NULL,
    [Date] DATE Default NULL
)
```
**Seen**:
```
CREATE TABLE Seen
(
    ID INT IDENTITY PRIMARY KEY Not NULL,
    [Movie_ID] INT Default NULL,
    [Date] VARCHAR(128) Default NULL,
    [Rating] INT Default NULL,
    [Comment] VARCHAR(128) Default NULL,
    FOREIGN KEY (Movie_ID) REFERENCES [dbo].[Movie](ID)
)
```
**Wishlist**:
```
CREATE TABLE Wishlist
(
    ID INT IDENTITY PRIMARY KEY Not NULL,
    [Movie_ID] INT Default NULL,
    [Date] VARCHAR(128) Default NULL,
    FOREIGN KEY (Movie_ID) REFERENCES [dbo].[Movie](ID)
)
```
