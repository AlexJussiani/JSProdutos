#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Services/JsProduto/JS.Produtos.API/JS.Produtos.API.csproj", "Services/JsProduto/JS.Produtos.API/"]
COPY ["./Services/JsProduto/building blocks/JS.EventSourcing/JS.EventSourcing.csproj", "Services/JsProduto/building blocks/JS.EventSourcing/"]
COPY ["./Services/JsProduto/building blocks/JS.Core/JS.Core.csproj", "Services/JsProduto/building blocks/JS.Core/"]
COPY ["./Services/JsProduto/building blocks/JS.WebAPI.Core/JS.WebAPI.Core.csproj", "Services/JsProduto/building blocks/JS.WebAPI.Core/"]
COPY ["./Services/JsProduto/JS.Produtos.Domain/JS.Produtos.Domain.csproj", "Services/JsProduto/JS.Produtos.Domain/"]
COPY ["./Services/JsProduto/JS.Produtos.Infra/JS.Produtos.Infra.csproj", "Services/JsProduto/JS.Produtos.Infra/"]
RUN dotnet restore "Services/JsProduto/JS.Produtos.API/JS.Produtos.API.csproj"
COPY . .
WORKDIR "./Services/JsProduto/JS.Produtos.API"
RUN dotnet build "JS.Produtos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JS.Produtos.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JS.Produtos.API.dll"]