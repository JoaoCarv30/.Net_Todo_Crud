using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Service;

var builder = WebApplication.CreateBuilder(args);


// Adiciona o DbContext ao container de dependências
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Adicione o serviço de controllers
builder.Services.AddControllers();  // IMPORTANTE: Adiciona suporte a controllers

// Adiciona outros serviços
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona o TaskService como Singleton
builder.Services.AddScoped<TaskService>();

var app = builder.Build();

// Configura o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Registra os controllers
app.MapControllers();  // Esta linha garante que as rotas de controllers sejam mapeadas

app.Run();