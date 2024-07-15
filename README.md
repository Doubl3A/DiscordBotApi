# Discord Bot Api
A simple API used to track user interactions with the bot and at the website.

# Development
- Developed and tested with `.Net 8.0`

Run the project locally with ```dotnet run``` or ```dotnet watch```

> [!IMPORTANT]
> This project uses user secret to store sensitive information when developing locally. Missing values that are needed in this file are represented as empty values in `appsettings.json`.

## Code style
To ensure coherence in code styling, we use an editor-config file with saved code formatting.
* Rider:
    * Go to `Settings -> Tools -> Actions on save`
    * Ensure that `Enable EditorConfig support` in checked in `Editor -> Code Style`
    * Enable `Reformat and cleanup code`
* Visual Studio:
    * `Options -> Text Editor -> Code Cleanup -> Run Code Clean Up profile on Save`

## Swagger documentation
For swagger documentation we use a ```DiscordBot.Api.xml``` file to save and load from. This is automatically generated at build. To enable this:
1. Right-click on the ```DiscordBot.Api``` project, and go to project properties.
2. Goto Configuration for the debug build, and ensure that the ```XML documentation --> Generate``` is enabled, and has the same relative path as the existing file (`DiscordBot.Api.xml`)