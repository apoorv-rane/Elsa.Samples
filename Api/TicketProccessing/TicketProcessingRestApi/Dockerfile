#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Api/TicketProccessing/TicketProcessingRestApi/TicketProcessingRestApi.csproj", "Api/TicketProccessing/TicketProcessingRestApi/"]
COPY ["Api/TicketProccessing/TicketProcessingRestApi.Repository/TicketProcessingRestApi.Repository.csproj", "Api/TicketProccessing/TicketProcessingRestApi.Repository/"]
COPY ["Api/TicketProccessing/TicketProcessingRestApi.Entities/TicketProcessingRestApi.Entities.csproj", "Api/TicketProccessing/TicketProcessingRestApi.Entities/"]
COPY ["Api/TicketProccessing/TicketProcessingRestApi.IRepository/TicketProcessingRestApi.IRepository.csproj", "Api/TicketProccessing/TicketProcessingRestApi.IRepository/"]
RUN dotnet restore "Api/TicketProccessing/TicketProcessingRestApi/TicketProcessingRestApi.csproj"
COPY . .
WORKDIR "/src/Api/TicketProccessing/TicketProcessingRestApi"
RUN dotnet build "TicketProcessingRestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketProcessingRestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketProcessingRestApi.dll"]