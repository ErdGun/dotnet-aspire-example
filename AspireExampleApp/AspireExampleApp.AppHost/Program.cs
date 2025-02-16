var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireExampleApp_ApiService>("apiservice");

builder.AddProject<Projects.AspireExampleApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
