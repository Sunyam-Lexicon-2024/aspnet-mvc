FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm
USER vscode
WORKDIR /workspace
RUN \
    dotnet tool install --global dotnet-ef && \
    dotnet tool update --global dotnet-ef