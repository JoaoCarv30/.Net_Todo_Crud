using Todo.Service;

var builder = WebApplication.CreateBuilder(args);

// Adicione o serviço de controllers
builder.Services.AddControllers();  // IMPORTANTE: Adiciona suporte a controllers

// Adiciona outros serviços
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona o TaskService como Singleton
builder.Services.AddSingleton<TaskService>();

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