using DiscordBot.Api.Extensions.Startup;
using Serilog;

// Setup logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

// Initiate app builder
var builder = WebApplication.CreateBuilder(args);

// Add serilog as application logger
builder.AddConfiguredSerilog();

// Add controllers
builder.Services.AddControllers(options => { options.ReturnHttpNotAcceptable = true; })
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

// Add problem details to errored requests
builder.Services.AddProblemDetails();

// Initiate Db contexts
builder.AddConfiguredDb();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load customization for api versioning and swagger
builder.Services.AddCustomApiVersioning();
builder.Services.LoadSwaggerDocumentation();

// Add custom services to the application
builder.AddCustomServices();

// Build the application and configure the HTTP pipeline
var app = builder.Build();

app.UseDevelopSpecificCustomization();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
