using Backend_API.SqlModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Step 1 : Add appsetting.json configuration
// Adding appsettings.json manually for environment-specific config reading

var buildConfig = builder.Configuration;
buildConfig.AddJsonFile("appsetting.json", optional: true, reloadOnChange: true);

#endregion

#region Step 2 :  Read the SqlEndPoint value from appsetting.json

// Manually creating configuration object to extract custom config sections
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Bind SqlEndPoint section to a class
var sqlConnection = config.GetSection("SqlEndPoint").Get<SqlEndPoint>();

#endregion

#region Step 3: Register the Dependency in DI Container

builder.Services.AddSingleton(sqlConnection);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHealthChecks("/health");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
