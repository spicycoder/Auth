var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloak(
    "keycloak",
    8282)
    .WithDataVolume()
    .WithExternalHttpEndpoints();

var simpleAuth = builder.AddProject<Projects.SimpleAuth>("simple-auth");

var externalAuth = builder.AddProject<Projects.ExternalAuth>("external-auth")
    .WithExternalHttpEndpoints()
    .WithReference(keycloak)
    .WaitFor(keycloak);

builder.Build().Run();
