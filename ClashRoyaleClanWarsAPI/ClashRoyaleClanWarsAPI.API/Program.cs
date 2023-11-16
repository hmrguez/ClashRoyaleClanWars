using ClashRoyaleClanWarsAPI.API.OptionsSetup;
using ClashRoyaleClanWarsAPI.Application;
using ClashRoyaleClanWarsAPI.Infrastructure;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ClashRoyaleDbContext>()
                .AddDefaultTokenProviders();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

    builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
    builder.Services.ConfigureOptions<JwtSettingsSetup>();

    builder.Services.AddAutoMapper(typeof(Program));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Standard authorization header using bearer scheme (\"bearer {token}\")",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("NewPolicy", app =>
        {
            app.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                .AllowAnyHeader().AllowAnyMethod();
        });
    });
       
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("NewPolicy");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

