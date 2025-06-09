using Microsoft.EntityFrameworkCore;
using PocheteAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseMySql(
    builder.Configuration.GetConnectionString("MariaDBConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDBConnection"))
 ));

// Configura CORS para permitir qualquer origem, cabeçalhos e métodos
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Outros serviços...
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração padrão de middlewares
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use o middleware CORS com a política configurada
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();