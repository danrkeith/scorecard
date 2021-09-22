# SCORECARD

## Video Demo

<URL>

## Running the Application

1. Navigate to the project directory
2. Run the project locally
	- For Windows:

			cd .\bin\Release\netcoreapp3.1\publish
			start .\ScoreCardv2-win-x64

	- For MacOS:

			cd .\bin\Release\netcoreapp3.1\publish
			chmod +x .\ScoreCardv2-osx-x64
			.\ScoreCardv2-osx-x64

	- For 64-Bit Linux (e.g. Ubuntu):

			cd .\bin\Release\netcoreapp3.1\publish
			chmod +x .\ScoreCardv2-linux-x64
			.\ScoreCardv2-linux-x64

	- For 32-Bit ARM Linux (e.g. Raspbian)

			cd .\bin\Release\netcoreapp3.1\publish
			chmod +x .\ScoreCardv2-linux-arm
			.\ScoreCardv2-linux-arm

3. Navigate to the URL specified in the console window

## Description

### Summary

This website acts as a platform to keep score of card games. It is written to support the game '500', and also allows the user to simply add scores independant of any automated
scoring in the form of a 'Blank Game'. If a user is logged in, they are also able to resume their last 500 game or blank game.

The file structure is in the MVC (Model, View, Controller) format. The model files contain classes in which information is passed between the controller & view. The view files
contain the html files and layouts which are shown to the user and are generated client-side. The controller files run the server-side processing, such as data-accessing and
computations.

### .\wwwroot

- .\wwwroot\app_data\Data.db - A SQLite database file that contains all user and game data.
- .\wwwroot\css\site.css - The stylesheet applied to all html pages.
- .\wwwroot\js\site.js - Contains a script to ensure that all necessary elements of a form are appropriately filled before allowing a user to continue
- .\wroot\lib - Contains files for the bootstrap and jquery libraries

## Example Account Included

Username: `cs50`

Password: `harvard`

## References

- DOTNET (ASP.NET, SQLite.Net)
	- https://docs.microsoft.com/en-us/documentation/
- JQuery
	- https://www.w3schools.com/jquery/
- .\Encryption.cs
	- https://www.c-sharpcorner.com/article/encryption-and-decryption-using-a-symmetric-key-in-c-sharp/
- Javascript Closures
	- https://stackoverflow.com/questions/21010963/how-to-get-outer-loop-index-inside-anonymous-function-call
- ASP.NET App settings
	- https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/
	- .\Controllers\UserController.cs Line 14-21
- SQLite iterative parameter insertion
	- https://stackoverflow.com/questions/2377506/pass-array-parameter-in-sqlcommand
	- .\SQLite.cs Line 50-72
- Css Additions (~\wwwroot]\css\site.css)
	- https://codepen.io/jnbruno/pen/vNpPpW