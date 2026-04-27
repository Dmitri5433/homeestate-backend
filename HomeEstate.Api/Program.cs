using HomeEstate.DataAccess;
using HomeEstate.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

DbSession.ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection")!;

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
    using (var db = new ApartmentContext()) { db.Database.EnsureCreated(); }
    using (var db = new UserContext()) { db.Database.EnsureCreated(); }
}

if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }

app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();
