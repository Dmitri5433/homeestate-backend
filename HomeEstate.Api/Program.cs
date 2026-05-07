using HomeEstate.DataAccess;
using HomeEstate.DataAccess.Context;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.BusinessLogic.Functions.Cities;
using HomeEstate.BusinessLogic.Functions.Auth;
using HomeEstate.BusinessLogic.Functions.Apartments;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection")!;
DbSession.ConnectionStrings = connString;

builder.Services.AddDbContext<ApartmentContext>(opt => opt.UseSqlServer(connString));
builder.Services.AddDbContext<UserContext>(opt => opt.UseSqlServer(connString));

builder.Services.AddScoped<ICityActions, CityFlow>();
builder.Services.AddScoped<IAuthActions, AuthFlow>();
builder.Services.AddScoped<IApartment, ApartmentFlow>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173",
            "http://localhost:5174",
            "http://localhost:5175",
            "http://localhost:5176",
            "https://homeestate-peach.vercel.app"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var apartmentDb = scope.ServiceProvider.GetRequiredService<ApartmentContext>();
    if (apartmentDb.Database.GetPendingMigrations().Any())
        apartmentDb.Database.Migrate();

    var userDb = scope.ServiceProvider.GetRequiredService<UserContext>();
    if (userDb.Database.GetPendingMigrations().Any())
        userDb.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();
