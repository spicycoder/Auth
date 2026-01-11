var builder = DistributedApplication.CreateBuilder(args);

var simpleAuth = builder.AddProject<Projects.SimpleAuth>("simple-auth");

builder.Build().Run();
