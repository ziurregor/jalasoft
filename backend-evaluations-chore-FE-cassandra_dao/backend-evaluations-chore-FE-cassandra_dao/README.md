# EVA - Backend Evaluations
EVA - Backend Evaluations is a cross-platform backend microservice developed in C# 7 with .NET Core platform. It's implemented with a microservice layered architecture. Some of its technical characteristics are:
* Self-hosted [Kestrel](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-2.2) server, a cross-platform web server for ASP.NET Core
* A REST API that follows a subset of [JSON:API](https://jsonapi.org/format/) specification
* MongoDB non-relational database persistence for evaluations resource
* In-memory persistence for templates, answers and scores

Either to get running an already built and downloaded artifact, or to start developing for the project, you must go over the *Prerequisites* section. To handle configurations go over *Configuration section*. To start using and testing the application, go to *Usage* section.

For a development environment setup, go to *Additional Setup for Development* section.

## Prerequisites
Install the next dependencies on the system:
* .NET Core 2.1 SDK. Download from [here](https://dotnet.microsoft.com/download/dotnet-core/2.1).
* MongoDB 3+ Community Server. Download from [here](https://www.mongodb.com/download-center/community). On Windows, during installation select the "Start as service" option.

### MongoDB Bootstrap
After MongoDB installation, you must verify `mongod` process is running in the background. Default configured port is `27017`..

### On Ubuntu Linux
MongoDB stores its data files in `/var/lib/mongodb` and its log files in `/var/log/mongodb` by default, runs using the `mongodb` user account, and keeps its configuration file in `/etc/mongod.conf`.

To start `mongod` run the following command in bash:
```bash
sudo service mongod start
```

To verify that `mongod` process has started successfully, check the contents of the log file at `/var/log/mongodb/mongod.log` for a line reading `[initandlisten] waiting for connections on port <port>`:
```bash
sudo cat /var/log/mongodb/mongod.log | less
```

For more Ubuntu-related information please go over the [official documentation](https://docs.mongodb.com/v3.2/tutorial/install-mongodb-on-ubuntu/).

### On Windows
First of all don't forget to [create the data directory](https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/#create-database-directory) where MongoDB stores data. To create this directory open a command prompt and run:
```powershell
md \data\db
```

To start `mongod.exe`, identify the installation directory and issue the following on a command prompt:
```powershell
"C:\Program Files\MongoDB\Server\3.2\bin\mongod.exe"
```
If a `waiting for connections` message is shown in the console output, indicates that the `mongod.exe` process is running successfully.

For more Windows-based information, like [how to start `mongod.exe` as a service](https://docs.mongodb.com/v3.2/tutorial/install-mongodb-on-windows/#install-the-mongodb-service) please go over the [official documentation](https://docs.mongodb.com/v3.2/tutorial/install-mongodb-on-windows/#configure-a-windows-service-for-mongodb-community-edition).

## Configuration
> For development, before cloning, and in order to avoid the hassle of providing your username and password, it's recommended to setup [SSH authentication](https://docs.gitlab.com/ee/ssh/) against GitLab.

We use a `.config` file to decouple environment variables from codebase. In a deployment scenario, this file is located inside `build` folder with the name `Jalasoft.Eva.Evaluations.Api.Server.dll.config`. In a development scenario, it's called `App.config` and lives under `\src\api\Jalasoft.Eva.Evaluations.Api.Server`. 

In both scenarios, make sure that:
* Port `8087` is available. If not you can change the `apiUrl` property on the configuration file with the port you have available.
  ```xml
  <add key="apiUrl" value="http://localhost:8087" />
  ```
* MongoDB daemon is running in port `27017`. If it's not running locally or you want to use another port, change the `dbConnection` property.
  ```xml  
  <add key="dbConnection" value="mongodb://localhost:27017/eva" />  
  ```

## Usage
Currently we're using a framework-dependent deployment ([FDD](https://docs.microsoft.com/en-us/dotnet/core/deploying/)) that relies on the presence of a shared system-wide version of .NET Core on the target system. So to run the application we use the `dotnet` CLI.

On Windows, navigate to the `build` folder and execute:
```powershell
> dotnet .\Jalasoft.Eva.Evaluations.Api.Server.dll
```
On Linux:
```bash
$ dotnet ./Jalasoft.Eva.Evaluations.Api.Server.dll
```
Then, to check if the service is running properly make a request to `http://IP_MACHINE:8087/api/v1/health` endpoint. You can achieve this trough [Postman](https://learning.getpostman.com/docs/postman/launching_postman/sending_the_first_request/), [Curl](https://www.keycdn.com/support/popular-curl-examples) or any web browser. The response should look like this:
```json
{
    "application": {
        "id": "11111111-1111-1111-1111-111111111111",
        "name": "Evaluations API",
        "version": "0.0.3456"
    },
    "status": "Up"
}
```
The content of this response is based on the `ApplicationInfo.json` file which is part of `Jalasoft.Eva.Evaluations.Api.Server` project. Last three digits of `version` property are taken out from the GitLab CI pipeline number from which the artifact was built upon.

## Additional Setup for Development
* Visual Studio 2017+ IDE. Download from [here](https://visualstudio.microsoft.com/downloads/). During installation process don't forget to add support for .NET Core development. On Linux-based systems, you can use [MonoDevelop](https://www.monodevelop.com/download/#fndtn-download-lin) or Visual Code.
* Postman, to make requests against the REST API. Download from [here](https://www.getpostman.com/downloads/) 
* NodeJS 10.15.3. We use NodeJS to generate RAML API documentation and run Postman-based integration tests (aka BvTs) with [Newman](https://learning.getpostman.com/docs/postman/collection_runs/command_line_integration_with_newman/). We encourage the use of a node version manager before installing NodeJS on your system. Download here for [Linux](https://github.com/nvm-sh/nvm) or [Windows](https://github.com/coreybutler/nvm-windows). On Windows, if you face the error `exit status 1: 'C:\Users\YourUsername' is not recognized as an internal or external command, operable program or batch file.` after a successful nvm installation, probably it's because your username has spaces on it. A fix to this is to edit your nvm `settings.txt` file and use the alternate Windows folder naming scheme which does not have spaces. To find the alternate naming schema for your user directory, navigate to Windows `Users` directory, open CMD and execute `dir /x`. Update `setting.txt` accordingly, the property will look like this now: `root: C:\Users\SEPARA~1\AppData\Roaming\nvm`.
* Raml2html npm package, to generate local RAML-based API documentation. Open a CLI and run `npm i -g raml2html`.

### Optional
* Visual Code. Download from [here](https://code.visualstudio.com/download). Given the fact that .NET Core is targeted to multiplatform development, you can use this text editor, or the one of your preference, as an alternative to VS IDE. Just bear in mind you will need some [extra configuration](https://code.visualstudio.com/docs/languages/dotnet) and be familiar with CLI interaction
* Robo 3T, previously known as RoboMongo, a GUI for MongoDB administration.  Download from [here](https://robomongo.org/download)

### How to Update RAML documentation?
Proceed to update RAML docs (`docs/rest-docs.raml`) after a refactor which affects a controllers response, e.g, when there's a new property on a resource structure.
1. Identify the files involved, e.g, for `evaluation` resource there are two files referenced in `rest-docs.raml`, one is the raw JSON endpoint response (`examples/evaluations.json`), and the other is the semi-automatically generated inferred JSON schema (`schemas\evaluation.schema`).
2. Make a request to the endpoint involved. Then, copy the output to the clipboard. 
3. Go to [JSONschema.net](https://www.jsonschema.net/). Paste the output and infer the schema by clicking on "Infer Schema" button.
4. Copy the the newly generated schema to the clipboard. Before copying, select the second output view mode in order to make sure you're not copying the content with code lines embedded.
5. Paste the content to the `*.schema` file
6. Finally, navigate to `docs` folder and run `raml2html rest-docs.raml > index.html`. If there are no syntax errors, you should see a clean output with no messages.

> **Note on StyleCop:** Static code analysis for the project is made trough StyleCop.Analyzers package. If by any chance you have installed the VS StyleCop extension, you will see plenty or errors raised on VS Error List tab. Please **consider uninstalling the StyleCop extension (.vsix)** from VS since StyleCop analyzers package (which is already configured in the project) is [recommended over the extension](https://github.com/StyleCop/StyleCop#considerations).

## License
Copyright &copy; 2019 Jalasoft, Inc. All rights reserved.