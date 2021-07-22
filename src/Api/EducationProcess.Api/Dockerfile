#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Api/EducationProcess.Api/EducationProcess.Api.csproj", "Api/EducationProcess.Api/"]
COPY ["Api/EducationProcess.Domain/EducationProcess.Domain.csproj", "Api/EducationProcess.Domain/"]
COPY ["Api/EducationProcess.BusinessLogic/EducationProcess.Services.csproj", "Api/EducationProcess.BusinessLogic/"]
COPY ["Api/EducationProcess.DataAccess/EducationProcess.DataAccess.csproj", "Api/EducationProcess.DataAccess/"]
COPY ["Api/EducationProcess.Core/EducationProcess.Core.csproj", "Api/EducationProcess.Core/"]
RUN dotnet restore "Api/EducationProcess.Api/EducationProcess.Api.csproj"
COPY . .
WORKDIR "/src/Api/EducationProcess.Api"
RUN dotnet build "EducationProcess.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EducationProcess.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EducationProcess.Api.dll"]