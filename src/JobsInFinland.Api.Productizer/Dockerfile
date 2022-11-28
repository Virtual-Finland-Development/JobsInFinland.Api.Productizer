FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["JobsInFinland.Api.Productizer/JobsInFinland.Api.Productizer.csproj", "JobsInFinland.Api.Productizer/"]
RUN dotnet restore "JobsInFinland.Api.Productizer/JobsInFinland.Api.Productizer.csproj"
COPY . .
WORKDIR "/src/JobsInFinland.Api.Productizer"
RUN dotnet build "JobsInFinland.Api.Productizer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JobsInFinland.Api.Productizer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobsInFinland.Api.Productizer.dll"]
