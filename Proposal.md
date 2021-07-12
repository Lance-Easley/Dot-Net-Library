# .NET Library

## Description & Motivation

To get prepared for work at Core Logic, I will be building a Restful CRUD API using Dot Net Core with a front-end built with KnockoutJS. This API will be a library-themed system, where books can be interacted with through GET, POST, PUT, and DELETE requests. Such requests will be made either manually, or through a front-end interface. Through this project, I will become familiar with Dot Net Core and KnockoutJS, two technologies that I will run into when working at Core Logic.

## Prior Art

CRUD APIs have been around for a long time. From what I've seen from using Dot Net Core, this project's workflow seems to combine parts of Django and Spring. Dot Net Core's API development uses an MVC framework similar to Spring, while also using migrations to sync models to your database as Django does. I haven't made an application with an exposed API like this project requires, but there shouldn't be too many deviations from making a website (aside from HTML/CSS work).

## Core User Workflows

All interactions with the library data will be through the API. The front-end component will interact with the API to receive the data to display.

- **GET:**
/api/books - Returns all books.
/api/book/{id} - Returns the book that has the supplied id.

- **POST:**
/api/book - Creates the book supplied.

- **PUT:**
/api/book/{id} - Updates the book that matches the id provided.

- **DELETE:**
/api/book/{id} - Deletes the book that matches the id provided.

The front-end will consist of a single page with a list of all the books. There will be a button to add a book, and each row will have buttons to edit and delete a book.

## Project Timeline

**Week 1:**
I will be learning and understanding both Dot Net Core and KnockoutJS during this week. If I get comfortable enough early, I will set up the base code for the API. (I will not be able to work as much Tuesday, Wednesday, and Thursday due to MSU's Dev Dawgs Camp)

**Week 2:**
I will dedicate this whole week to developing just the API side of the project. I will get all the HTTP requests wired up and set up the database. Depending on pricing, I may have to use MySQL instead of a Microsoft SQL Server if I can't get it for free.

**Week 3:**
This week will be front-end work with KnockoutJS. With the API built up, I can make the GUI/webpage for the user to interact with.

**Week 4:**
If there is any work that took longer than anticipated, I will get it done this week. If I finish, then I will first work on getting feedback and adjusting the user experience on the front-end. Otherwise, I will be fixing bugs and strengthening the project.

## Technologies

- .NET
- KnockoutJS
- SQL

## Git Hub Link

https://github.com/Lance-Easley/Dot-Net-Library
