FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm AS build
USER vscode
WORKDIR /workspace
COPY . .
WORKDIR /workspace/Storage
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet tool update --global dotnet-ef 

FROM build AS development
USER vscode
WORKDIR /workspace/Storage
