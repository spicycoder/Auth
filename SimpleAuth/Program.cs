using AspNetCore.Swagger.Themes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleAuth;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = IdentityConstants.BearerScheme;
        options.DefaultChallengeScheme = IdentityConstants.BearerScheme;
    })
    .AddBearerToken(IdentityConstants.BearerScheme)
    .AddCookie(IdentityConstants.ApplicationScheme);

builder.Services
    .AddAuthorizationBuilder()
    .SetDefaultPolicy(new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(
            IdentityConstants.BearerScheme,
            IdentityConstants.ApplicationScheme)
        .RequireAuthenticatedUser()
        .Build());

builder.Services.AddDbContext<AppDBContext>(x => x.UseSqlite("DataSource=app.db"));

builder.Services
    .AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<AppDBContext>()
    .AddApiEndpoints();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().AllowAnonymous();
    app.UseSwaggerUI(
        Theme.Futuristic,
        options => options.SwaggerEndpoint("/openapi/v1.json", "Cookies Auth"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapIdentityApi<IdentityUser>();
app.MapControllers();

app.Run();