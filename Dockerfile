FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
 
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["cpfvalidator/cpfvalidator.csproj", "cpfvalidator/"]
RUN dotnet restore "cpfvalidator/cpfvalidator.csproj"
COPY . .
WORKDIR "/src/cpfvalidator"
RUN dotnet build "cpfvalidator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "cpfvalidator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "cpfvalidator.dll"]