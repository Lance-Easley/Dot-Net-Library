# Dot Net Library

Dot Net Library is my Capstone Project for Base Camp Coding Academy. 
The project is designed to get familiar with the technologies used at Core Logic.
In short, it is a library-themed API that allows for the manipulation of books through HTTP request.
For more details about the project's requirements and life-cycle, view *Proposal.md*.

## Usage

For now, the project only runs locally, along with a local Microsoft SQL Server (Database Connection can easily change).
Once a SQL server is running, you can run the project by navigating to the folder in a terminal and running `dotnet run`.
After that, the API boots up and will respond to HTTP requests.

For a user-friendly interaction with the API, navigate to the base URL. 
You will be greeted with a list of all books and buttons to interact with the books.

All interactions with the API are logged to a database table. 
To view these logs, navigate to `/logs` in the url.
