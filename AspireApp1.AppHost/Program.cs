var builder = DistributedApplication.CreateBuilder(args);

var dbName = "mycatalog"; // MySql database & table names are case-sensitive on non-Windows.
var mydb = builder.AddMySql("mysql")
  //.WithImageTag("5.7")
  //.WithPhpMyAdmin()
  // Set the name of the database to auto-create on container startup.
  .WithEnvironment("MYSQL_DATABASE", dbName)
  // Mount the SQL scripts directory into the container so that the init scripts run.
  .WithBindMount("./data", "/docker-entrypoint-initdb.d")
  // Add the database to the application model so that it can be referenced by other resources.
  .AddDatabase(dbName);

var apiService = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice")
  .WithReference(mydb);

builder.AddProject<Projects.AspireApp1_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
