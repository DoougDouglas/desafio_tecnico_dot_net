using EclipseWorks.DesafioTecnico.Api.Extensions;
using EclipseWorks.DesafioTecnico.Services.Extensions;
using EclipseWorks.DesafioTecnico.Domain.Extensions;
using EclipseWorks.DesafioTecnico.Repository.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .RegisterDomainDependencies()
    .RegisterApiDependencies(builder.Configuration)
    .RegisterBusinessDependencies()
    .RegisterRepositoryDependencies();

var app = builder.Build();

app.RegisterMiddlewares()
    .RegisterSwaggerRoute();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseCors("*");

app.MapControllers();
app.MigrateDatabase();

app.Run();
