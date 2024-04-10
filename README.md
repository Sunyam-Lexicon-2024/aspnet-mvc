# MVC 1 (Assignment 11)

## Description

A basic ASP.NET Core 8.0 MVC application

## Testing/Development

It's possible to utilize VSCode Dev Containers right away (or `docker-compose up`)

*Do note* that the Dev Container environment is configured to run via the Podman Docker Emulator 
in rootless mode, so it is important that you configure the DOCKER_HOST to the correct socket
and configure Podman to persist your relevant user namespace (e.g. userns="keep-id").

If you do not want to use a Container enviroment you can of course run the application as usual locally.

```
# Local development
cd Storage
dotnet run
```

## Contact
[visualarea.1@gmail.com](mailto:visualarea.1@gmail.com)