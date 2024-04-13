FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm AS build 
USER vscode
WORKDIR /workspace
ADD . .

FROM build AS development
USER vscode
WORKDIR /workspace/Storage
COPY --from=build . .
RUN \
    dotnet tool install --global dotnet-ef && \
    dotnet tool update --global dotnet-ef