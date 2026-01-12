using AspNetCore.Swagger.Themes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var keycloakConnection = builder.Configuration["KEYCLOAK_HTTP"];

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        {
            options.Authority = $"{keycloakConnection}/realms/AuthRealm"; // "http://localhost:8282/realms/AuthRealm";
            options.RequireHttpsMetadata = false;
            options.Audience = "account";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().AllowAnonymous();
    app.UseSwaggerUI(
        Theme.Futuristic,
        options => options.SwaggerEndpoint("/openapi/v1.json", "External Auth"));
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();