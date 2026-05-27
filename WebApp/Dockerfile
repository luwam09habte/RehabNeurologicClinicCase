from mcr.microsoft.com/dotnet/aspnet:10.0 as base
workdir /app
expose 8080

from mcr.microsoft.com/dotnet/sdk:10.0 as build
arg build_configuration=release
workdir /src
copy ["WebApp/WebApp.csproj", "WebApp/"]
copy ["Core/Core.csproj", "Core/"]
run dotnet restore "WebApp/WebApp.csproj"
copy . .
workdir "/src/WebApp"
run dotnet publish "WebApp.csproj" -c $build_configuration -o /app/publish /p:useapphost=false

from base as final
workdir /app
copy --from=build /app/publish .
entrypoint ["dotnet", "WebApp.dll"]
