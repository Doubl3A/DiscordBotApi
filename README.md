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

## Branches
All development branches should branch out of the `develop` branch. New changes should be merged inn with a PR to the develop branch.
The `main` branch should reflect what is live in production.

### Naming
Branches should be named based on the GitHub task they are connected to with this format: `[task tag]/[task name]`.
Ex. a task with the tag `feature` and a title of `API Authentication` should have the following branch `feature/api-authentication` (kebab case).
Tasks with excessive names can be shortened down to be more readable.