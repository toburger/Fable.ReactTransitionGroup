# Fable.ReactTransitionGroup

Fable bindings for [react-transition-group](https://reactcommunity.org/react-transition-group/)

## Publish a new version

Host your nuget API key inside a `NUGET_KEY` environnement variable, it will allow us to access it from CLI.

1. Update the version in the *.fsproj file
2. Run `dotnet pack ./src -c Release`
3. Run `dotnet nuget push .\src\bin\Release\Fable.ReactTransitionGroup.<version>.nupkg -s nuget.org -k <nuget_key>`

Make sure to replace `<version>` with the version you want to publish

`<nuget_key>` is your Nuget API key you can access it like that:
- From cmd: `%NUGET_KEY%`
- From cmd: `$env:NUGET_KEY`
- From bash: `$NUGET_KEY`
