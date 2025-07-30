<h1 align="center">
   <a href="#"> Nexus NPS Backend </a>
</h1>

<h3 align="center">
    Set of backend tools for integration with Nexus NPS Frontend and integration with other tools.
</h3>

</p>

<h4 align="center">
	 Status: development
    <!-- Status: Finished -->
</h4>

<p align="center">
 <a href="#about">About</a> �
 <a href="#how-to-run">How to Run</a>

</p>

## About

The Nexus NPS backend is a solution that allows review registration of some products and the visualization of their respective scores.

---

## How to run

Have .NET 8 installed, or compatible system

### Pre-requisites

Before you begin, you will need to have the following tools installed on your machine:
Windows
[.Net 8.0.100 or better (64-bit)](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)

[Visual Studio Code](https://code.visualstudio.com/) (Windows/Linux/MacOs)

[Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) (Windows)

#### Run in VsCode or Terminal

```bash

# Access the project folder cmd/terminal or vscode
$ Hydro.Dashboard.BackEnd\Hydro.Dashboard.Api.sln

# Run the command in the terminal
$ dotnet run

# Access the link by entering the port entered at the time of compilation
$ http://localhost:[port]/swagger/index.html

```

#### Run in Visual Studio 2022

```bash

# Access the solution in root folder
$ Neuxs.NPS.Api

# mark api as startup project
$ Nexus.NPS.Api.csproj

# start application using the top menu
$ http

# Access the link by entering the port entered at the time of compilation
$ http://localhost:[port]/swagger/index.html
$ Default port is set to 5000

```
### How To Setup PostgreSql DB
```
# Using pgAdmin 4, create a new database named NexusNpsDB and leave Owner as postgres
$ Right Click -> Create -> Database...
$ Click Save

# Right Click the new database -> Restore
$ On Filename field, find and select the mydb_backup.backup file found on this project folder
$ Click Restore
```
