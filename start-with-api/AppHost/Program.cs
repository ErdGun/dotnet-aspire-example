var builder = DistributedApplication.CreateBuilder(args);

var myCache = builder.AddRedis("cache")
    .WithRedisCommander();

var api = builder.AddProject<Projects.Api>("api")
    .WithReference(myCache);
var web = builder.AddProject<Projects.MyWeatherHub>("myweatherhub")
    .WithReference(api)
    .WithExternalHttpEndpoints();

builder.Build().Run();
