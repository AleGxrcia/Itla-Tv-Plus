<!-- ABOUT THE PROJECT -->
# About ITLA Tv+

ITLA Tv+ is a streaming video application built using ASP.NET Core MVC.

ITLA Tv+ includes the following key functionalities:

* **Home:** The main screen with a menu for navigation to different sections such as series management, producer management, and genre management.
* **Series Management:** Allows for creating, editing, and deleting series. Provides options for adding series details like name, cover image, YouTube video link, primary genre, and secondary genre.
* **Producer Management:** Enables the creation, editing, and deletion of producers.
* **Genre Management:** Facilitates the management of genres, including creation, editing, and deletion.
<br>

## Technologies

- **Frontend**
  - HTML
  - CSS
  - Bootstrap
  - ASP.NET Razor

- **Backend**
  - C# ASP.NET Core (8.0)
    - Microsoft Entity Framework Core
      - Microsoft Entity Framework Core Relational
      - Microsoft Entity Framework Core SqlServer
      - Microsoft Entity Framework Core Tools
      - Microsoft Entity Framework Core Design
      - Microsoft Entity Framework Code First

- **ORM**
  - Entity Framework

- **Database**
  - SQL Server
<br>

## Project images

* Home

![Itla Tv+ Home](https://github.com/AleGxrcia/Itla-Tv-Plus/blob/main/ItlaTvPlus/wwwroot/images/Index.png)

* Series details

![Itla Tv+ Series details](https://github.com/AleGxrcia/Itla-Tv-Plus/blob/main/ItlaTvPlus/wwwroot/images/series-details.png)

* Series Management

![Itla Tv+ Series Management](https://github.com/AleGxrcia/Itla-Tv-Plus/blob/main/ItlaTvPlus/wwwroot/images/series-management.png)
<br>

## Prerequisites
To run ITLA Tv+, you'll need the following software and tools:

* Visual Studio 2022 onwards
* ASP.NET Core (8.0 onwards)
* SQL Server
<br>

## Installation

1. Download the project or clone it:

2. Open the project in Visual Studio 2022.

3. Open the file "appsettings.Development.json" and update the server name to match your environment, for example:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YourServerName;"
     },
     // other configurations...
   }
   ```
4. In Visual Studio, go to:
   ```
   Tools > NuGet packages manager > Package management console
   ```
5. In the package management console, ensure that the "Application" project is selected as the default project. You can set the default project by selecting it from the dropdown menu in the Package Management Console toolbar.
   
6. In the package management console, run the following commands:
   ```bash
   Update-Database
   ```
7. Run the project, and it will open in your default browser.

