# .NET Core Build
FROM microsoft/dotnet:latest AS dotnetcore-build
WORKDIR /source

# Copy Projects Files
COPY source/Application/Applications/Solution.Application.Applications.csproj ./Application/Applications/
COPY source/CrossCutting/AspNetCore/Solution.CrossCutting.AspNetCore.csproj ./CrossCutting/AspNetCore/
COPY source/CrossCutting/DependencyInjection/Solution.CrossCutting.DependencyInjection.csproj ./CrossCutting/DependencyInjection/
COPY source/CrossCutting/EntityFrameworkCore/Solution.CrossCutting.EntityFrameworkCore.csproj ./CrossCutting/EntityFrameworkCore/
COPY source/CrossCutting/Logging/Solution.CrossCutting.Logging.csproj ./CrossCutting/Logging/
COPY source/CrossCutting/Mapping/Solution.CrossCutting.Mapping.csproj ./CrossCutting/Mapping/
COPY source/CrossCutting/MongoDB/Solution.CrossCutting.MongoDB.csproj ./CrossCutting/MongoDB/
COPY source/CrossCutting/Security/Solution.CrossCutting.Security.csproj ./CrossCutting/Security/
COPY source/CrossCutting/Utils/Solution.CrossCutting.Utils.csproj ./CrossCutting/Utils/
COPY source/Domain/Domains/Solution.Domain.Domains.csproj ./Domain/Domains/
COPY source/Infrastructure/Database/Solution.Infrastructure.Database.csproj ./Infrastructure/Database/
COPY source/Model/Entities/Solution.Model.Entities.csproj ./Model/Entities/
COPY source/Model/Enums/Solution.Model.Enums.csproj ./Model/Enums/
COPY source/Model/Models/Solution.Model.Models.csproj ./Model/Models/
COPY source/Model/Validators/Solution.Model.Validators.csproj ./Model/Validators/
COPY source/Web/App/Solution.Web.App.csproj ./Web/App/

# ASP.NET Core Restore
RUN dotnet restore ./Web/App/Solution.Web.App.csproj

# Copy All Files
COPY source .

# ASP.NET Core Build
RUN dotnet build ./Web/App/Solution.Web.App.csproj -c Release -o /app

# ASP.NET Core Publish
FROM dotnetcore-build AS dotnetcore-publish
RUN dotnet publish ./Web/App/Solution.Web.App.csproj -c Release -o /app

# Angular
FROM node:alpine AS angular-build
ARG ANGULAR_ENVIRONMENT
WORKDIR /frontend
ENV PATH /frontend/node_modules/.bin:$PATH
COPY source/Web/App/Frontend/package.json .
RUN npm run restore
COPY source/Web/App/Frontend .
RUN npm run $ANGULAR_ENVIRONMENT

# ASP.NET Core Runtime
FROM microsoft/dotnet:2.1.5-aspnetcore-runtime AS aspnetcore-runtime
WORKDIR /app
EXPOSE 80

# ASP.NET Core and Angular
FROM aspnetcore-runtime AS aspnetcore-angular
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
WORKDIR /app
COPY --from=dotnetcore-publish /app .
COPY --from=angular-build /frontend/dist ./Frontend/dist
ENTRYPOINT ["dotnet", "Solution.Web.App.dll"]
