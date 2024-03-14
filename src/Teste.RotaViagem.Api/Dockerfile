#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Teste.RotaViagem.Api/Teste.RotaViagem.Api.csproj", "src/Teste.RotaViagem.Api/"]
COPY ["src/Teste.RotaViagem.Application/Teste.RotaViagem.Application.csproj", "src/Teste.RotaViagem.Application/"]
COPY ["src/Teste.RotaViagem.Domain/Teste.RotaViagem.Domain.csproj", "src/Teste.RotaViagem.Domain/"]
COPY ["src/Teste.RotaViagem.Infra/Teste.RotaViagem.Infra.csproj", "src/Teste.RotaViagem.Infra/"]
RUN dotnet restore "src/Teste.RotaViagem.Api/Teste.RotaViagem.Api.csproj"
COPY . .
WORKDIR "/src/src/Teste.RotaViagem.Api"
RUN dotnet build "Teste.RotaViagem.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teste.RotaViagem.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teste.RotaViagem.Api.dll"]