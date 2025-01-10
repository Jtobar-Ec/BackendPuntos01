using Microsoft.EntityFrameworkCore;
using PuntosRecompensasAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar CORS para cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Permite cualquier origen
              .AllowAnyMethod() // Permite cualquier m�todo HTTP
              .AllowAnyHeader(); // Permite cualquier cabecera
    });
});

// Agregar soporte para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar la tuber�a de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Puntos Recompensas API v1");
        options.RoutePrefix = string.Empty; // Esto asegura que Swagger UI est� en la ra�z de la URL
    });
}

// Usar CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
