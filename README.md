# Dot Net Library

Dot Net Library is my Capstone Project for Base Camp Coding Academy. 
The project is designed to get familiar with the technologies used at Core Logic.
In short, it is a library-themed API that allows for the manipulation of books through HTTP request.
For more details about the project's requirements and life-cycle, view *Proposal.md*.

## Usage

This project is ran through a docker-compose configuration. 
The images required are the [dotnetlibrary image](https://hub.docker.com/repository/docker/techmine20/dotnetlibrary) and the [Microsoft SQL image](https://hub.docker.com/_/microsoft-mssql-server). 
When using a fresh mssql container, make sure that dotnetlibrary's `DBMigrate` variable is set to `"y"`.
After that, you can get rid of `DBMigrate`.
After composing and running the application, the API boots up and will respond to HTTP requests.

For a user-friendly interaction with the API, navigate to the base URL. 
You will be greeted with a list of all books and buttons to interact with each book.

All interactions with the API are logged to a database table. 
To view these logs, click on `Logs` in the navbar.
The logs page contains a list of all log entries.
To filter through all the logs, toggle the checkboxes on the left-hand side, which allows you to select only the log methods you want to see.

To go back to the list of books, simply click on `Books` in the navbar.
