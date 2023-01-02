using Minimal_Web_API.DataContext;
using Minimal_Web_API.DTO;
using Minimal_Web_API.Repositories;
using Minimal_Web_API.Services;
using NuGet.Protocol.Plugins;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PTTContext>();
builder.Services.AddTransient(typeof(StopService));
builder.Services.AddTransient(typeof(StopRepository));
builder.Services.AddTransient(typeof(UserService));
builder.Services.AddTransient(typeof(UserRepository));
builder.Services.AddTransient(typeof(DataService));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials


app.MapGet("/", () => "Hello World!");

app.MapGet("/users", async (UserService userService)
    => await userService.GetUsersAsync());

app.MapGet("/users/{login}/{password}", async (UserService userService, string login, string password)
    => await userService.GetUserByLoginAndPassword(login, password));

app.MapGet("/users/{login}/stops", async (UserService userService, string login)
    => await userService.GetUserStops(login));

app.MapPost("/users/{login}/stops", (UserService userService, string login, ICollection<string> stopIds)
    => userService.SaveStopsForUser(login, stopIds));

app.MapGet("/users/{login}/stops/not-saved", async (UserService userService, string login)
    => await userService.GetStopsExceptSavedByUser(login));



app.MapGet("/stops", async (StopService pttService)
    => await pttService.GetStopsFromAPI());

app.MapGet("/stops/{stopId}/timetable", async (StopService pttService, string stopId)
    => await pttService.GetStopTimetableByStopId(stopId));

app.Run();