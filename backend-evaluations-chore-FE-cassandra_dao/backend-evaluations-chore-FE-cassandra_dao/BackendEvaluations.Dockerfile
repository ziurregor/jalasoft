FROM microsoft/dotnet:sdk AS build-env

# set working directory
RUN mkdir /app
WORKDIR /app

# Install node utilities
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash -
RUN apt install nodejs
RUN npm install -g raml2html

# Copy nuget.config
COPY nuget.config /app/nuget.config
COPY RestApi.sln /app/RestApi.sln

# Copy csproj (API)
COPY src/api/Jalasoft.Eva.Evaluations.Api.Rest/Jalasoft.Eva.Evaluations.Api.Rest.csproj /app/src/api/Jalasoft.Eva.Evaluations.Api.Rest/Jalasoft.Eva.Evaluations.Api.Rest.csproj
COPY src/api/Jalasoft.Eva.Evaluations.Api.Server/Jalasoft.Eva.Evaluations.Api.Server.csproj /app/src/api/Jalasoft.Eva.Evaluations.Api.Server/Jalasoft.Eva.Evaluations.Api.Server.csproj

# Copy csproj (Core)
COPY src/core/domain/Jalasoft.Eva.Evaluations.Domain/Jalasoft.Eva.Evaluations.Domain.csproj /app/src/core/domain/Jalasoft.Eva.Evaluations.Domain/Jalasoft.Eva.Evaluations.Domain.csproj
COPY src/core/services/Jalasoft.Eva.Evaluations.Services/Jalasoft.Eva.Evaluations.Services.csproj /app/src/core/services/Jalasoft.Eva.Evaluations.Services/Jalasoft.Eva.Evaluations.Services.csproj
COPY src/core/services/Jalasoft.Eva.Evaluations.Services.Facade/Jalasoft.Eva.Evaluations.Services.Facade.csproj /app/src/core/services/Jalasoft.Eva.Evaluations.Services.Facade/Jalasoft.Eva.Evaluations.Services.Facade.csproj
COPY src/core/services/Jalasoft.Eva.Evaluations.Services.Impl/Jalasoft.Eva.Evaluations.Services.Impl.csproj /app/src/core/services/Jalasoft.Eva.Evaluations.Services.Impl/Jalasoft.Eva.Evaluations.Services.Impl.csproj
COPY src/core/services/Jalasoft.Eva.Evaluations.Services.Stub/Jalasoft.Eva.Evaluations.Services.Stub.csproj /app/src/core/services/Jalasoft.Eva.Evaluations.Services.Stub/Jalasoft.Eva.Evaluations.Services.Stub.csproj

# Copy csproj (Dao)
COPY src/dao/Jalasoft.Eva.Evaluations.Dao/Jalasoft.Eva.Evaluations.Dao.csproj /app/src/dao/Jalasoft.Eva.Evaluations.Dao/Jalasoft.Eva.Evaluations.Dao.csproj
COPY src/dao/Jalasoft.Eva.Evaluations.Dao.Fs/Jalasoft.Eva.Evaluations.Dao.Fs.csproj /app/src/dao/Jalasoft.Eva.Evaluations.Dao.Fs/Jalasoft.Eva.Evaluations.Dao.Fs.csproj
COPY src/dao/Jalasoft.Eva.Evaluations.Dao.Mongo/Jalasoft.Eva.Evaluations.Dao.Mongo.csproj /app/src/dao/Jalasoft.Eva.Evaluations.Dao.Mongo/Jalasoft.Eva.Evaluations.Dao.Mongo.csproj
COPY src/dao/Jalasoft.Eva.Evaluations.Dao.Stub/Jalasoft.Eva.Evaluations.Dao.Stub.csproj /app/src/dao/Jalasoft.Eva.Evaluations.Dao.Stub/Jalasoft.Eva.Evaluations.Dao.Stub.csproj
COPY src/dao/Jalasoft.Eva.Evaluations.Dao.Cassandra/Jalasoft.Eva.Evaluations.Dao.Cassandra.csproj /app/src/dao/Jalasoft.Eva.Evaluations.Dao.Cassandra/Jalasoft.Eva.Evaluations.Dao.Cassandra.csproj


# Copy csproj (Tests)
COPY tests/api/Jalasoft.Eva.Evaluations.Api.Rest.Tests/Jalasoft.Eva.Evaluations.Api.Rest.Tests.csproj /app/tests/api/Jalasoft.Eva.Evaluations.Api.Rest.Tests/Jalasoft.Eva.Evaluations.Api.Rest.Tests.csproj
COPY tests/core/Jalasoft.Eva.Evaluations.Services.Impl.Tests/Jalasoft.Eva.Evaluations.Services.Impl.Tests.csproj /app/tests/core/Jalasoft.Eva.Evaluations.Services.Impl.Tests/Jalasoft.Eva.Evaluations.Services.Impl.Tests.csproj
COPY tests/dao/Jalasoft.Eva.Evaluations.Dao.Fs.Tests/Jalasoft.Eva.Evaluations.Dao.Fs.Tests.csproj /app/tests/dao/Jalasoft.Eva.Evaluations.Dao.Fs.Tests/Jalasoft.Eva.Evaluations.Dao.Fs.Tests.csproj
COPY tests/dao/Jalasoft.Eva.Evaluations.Dao.Mongo.Tests/Jalasoft.Eva.Evaluations.Dao.Mongo.Tests.csproj /app/tests/dao/Jalasoft.Eva.Evaluations.Dao.Mongo.Tests/Jalasoft.Eva.Evaluations.Dao.Mongo.Tests.csproj
COPY tests/dao/Jalasoft.Eva.Evaluations.Dao.Cassandra.Tests/Jalasoft.Eva.Evaluations.Dao.Cassandra.Tests.csproj /app/tests/dao/Jalasoft.Eva.Evaluations.Dao.Cassandra.Tests/Jalasoft.Eva.Evaluations.Dao.Cassandra.Tests.csproj

# Restore as distinc layers
RUN dotnet restore /app/RestApi.sln

# Copy everything else and build
COPY . ./
