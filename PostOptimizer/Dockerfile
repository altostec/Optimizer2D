FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY PostOptimizer/PostOptimizer.csproj PostOptimizer/
RUN dotnet restore PostOptimizer/PostOptimizer.csproj
COPY . .
WORKDIR /src/PostOptimizer
RUN dotnet build PostOptimizer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PostOptimizer.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PostOptimizer.dll"]