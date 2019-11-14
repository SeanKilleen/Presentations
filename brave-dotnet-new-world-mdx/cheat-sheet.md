# Cheat Sheet

## The Basics: Help

* `dotnet new /?`
* `dotnet new mvc /?`

## Installing from templates

* `dotnet new [templatename] [options]`
* e.g. `dotnet new sln --name HelloWorld`

## Listing

* `dotnet new --list`

## Installing

### From GitHub

* Clone repository
* `dotnet new -i [path]`

### From Nuget

* `dotnet new -i NugetPackageName`
* Can also use `--nuget-source` to specify your own nuget server

## References

* Good doc: https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates
* Template engine source code: https://github.com/dotnet/templating/
* Samples: https://github.com/dotnet/dotnet-template-samples
* Post-install actions: https://github.com/dotnet/templating/wiki/Post-Action-Registry
* Generators: https://github.com/dotnet/templating/wiki/Available-Parameter-Generators


## Demo Sequence

* Demo `dotnet new` with projects & solution
* Demo listing installed templates
* Demo help for a `dotnet new` and for a package, e.g. `dotnet new mvc /?`
* Demo installing the custom sample
* Demo uninstalling the custom sample (e.g. using `-u` to show the full path first)
* Open the project, demo project (showcase that it's a working project)
* Make updates to project
* Demo `type: generated` and `generator: port` in the custom sample
* Reinstall the template
* Get help for the template
* Fill it out
* Create the project in a new place
* Run it

## For the updated container demo

```bash
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-bionic
```

```bash
# Add wget
RUN apt-get update && apt-get install -y wget gnupg
```
