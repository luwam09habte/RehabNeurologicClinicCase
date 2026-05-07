using Core.Models;
using ServerAPI.Interfaces;
using ServerAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Injecter den rigtige klasse for IUserRepository
builder.Services.AddSingleton<IPatientRepository, FakePatientRepository>();
builder.Services.AddSingleton<IAdminRepository, FakeAdminRepository>();
builder.Services.AddSingleton<IQuestionnaireRepository, FakeQuestionnaireRepository>();
/*builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("ConnectionStrings"));*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.Run();