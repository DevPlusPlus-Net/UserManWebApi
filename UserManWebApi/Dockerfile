#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY InfraPackages InfraPackages2
COPY ["UserManWebApi/UserManWebApi.csproj", "UserManWebApi/"]
COPY ["UserDAL/UMDalContracts.csproj", "UserDAL/"]
COPY ["UMDTO/UMDTO.csproj", "UMDTO/"]
COPY ["UserServiceImpl/UserServiceImpl.csproj", "UserServiceImpl/"]
COPY ["UMUserContracts/UMUserContracts.csproj", "UMUserContracts/"]
COPY ["UMDalImpl/UMDalImpl.csproj", "UMDalImpl/"]
RUN dotnet restore "UserManWebApi/UserManWebApi.csproj"
COPY . .
WORKDIR "/src/UserManWebApi"
RUN dotnet build "UserManWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManWebApi.dll"]