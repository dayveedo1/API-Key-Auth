
using API_Key_Auth.Data.Config;
using ApiKeyAuth.Data.Config;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(/* x => x.Filters.Add<ApiKeyAuthFilter>() */);  // every API controller has this filter applied if implemented her

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };

    var requirement = new OpenApiSecurityRequirement
    {
        {scheme, new List<string>() }
    };

    c.AddSecurityRequirement(requirement);
});

builder.Services.AddScoped<ApiKeyAuthFilter>();   // can specify which controllers to apply this filter to


string AllowOrigins = builder.Configuration["Cors"];
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigins",
               builder =>
               {
                   builder.SetIsOriginAllowed(origin => true)
                //builder.WithOrigins(AllowOrigins)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();

               });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
