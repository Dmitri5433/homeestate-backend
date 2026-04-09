using HomeEstate.DataAccess;
using HomeEstate.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// Connection string -> DbSession (same pattern as eUShop)
DbSession.ConnectionStrings =
    builder.Configuration.GetConnectionString("DefaultConnection")!;

// Ensure DB and tables are created on startup
using (var db = new ApartmentContext())
{
    db.Database.EnsureCreated();
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS — allow React frontend on localhost:5173
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
