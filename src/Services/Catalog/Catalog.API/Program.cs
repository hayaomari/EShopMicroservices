var builder = WebApplication.CreateBuilder(args);
//Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
//register Marten for POSTgres SQL
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!)
    })
    .UseLightweightSessions();//for performance
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


//Configure the HTTP requests pipeline.
app.MapCarter();
app.Run();
