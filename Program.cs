using API_NET.Services;
using proyectoEF.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//agregando el servicio de BD
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

//esto es para la inyeccion de dependencias
//especificamente este es para pasar la interfaz y luego la clase esto limita si necesitamos mandar parametros a la clase
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();

//este es para la inyeccion de dependencias pero haciendo una instancia de manera que si podemos mandar parametros
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());


builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();


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

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();