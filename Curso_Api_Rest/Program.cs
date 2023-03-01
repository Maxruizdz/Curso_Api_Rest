using Curso_Api_Rest.Middleware;
using Curso_Api_Rest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IHelloWordService, HelloWordServices>();
builder.Services.AddScoped<IHelloWordService>(p=> new HelloWordServices());
builder.Services.AddScoped<ICategoriaService, CategoriasServices>();
builder.Services.AddScoped<ITareaServices, TareaServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
//app.UseWelcomePage();

app.UseTimeMiddleware();


app.MapControllers();

app.Run();
