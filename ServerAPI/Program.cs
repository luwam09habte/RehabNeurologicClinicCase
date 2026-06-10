using Core.Models;
using ServerAPI.Interfaces;
using ServerAPI.Repositories;

// Opretter en builder til vores API
var builder = WebApplication.CreateBuilder(args);

// Fortæller ASP.NET - Vi bruger controllers i dette AP
builder.Services.AddControllers();


// Dependency Injection betyder at ASP.NET opretter og giver controlleren det repository-objekt
// den skal bruge, i stedet for at controlleren selv laver det med "new"

// AddSingleton = der oprettes ét fælles repository-objekt, som genbruges
// Dependency Injection - siger når en controller beder om IxRepository, skal den få xRepository
builder.Services.AddSingleton<IPatientRepository, FakePatientRepository>();
builder.Services.AddSingleton<IAdminRepository, FakeAdminRepository>();

/*builder.Services.AddSingleton<IQuestionnaireRepository, FakeQuestionnaireRepository>();*/
builder.Services.AddSingleton<IQuestionnaireRepository, MongoQuestionnaireRepository>();

/*builder.Services.AddSingleton<IQuestionnaireAnswerRepository, FakeQuestionnaireAnswerRepository>();*/
builder.Services.AddSingleton<IQuestionnaireAnswerRepository, MongoQuestionnaireAnswerRepository>();

// CORS = frontend og backend må snakke sammen selvom de kører på forskellige adresser/ports
builder.Services.AddCors(options =>
{
    // Opretter policy der tillader alt
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

// Bygger selve webapplikationen 
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("policy");

// Aktiverer authorization middleware
app.UseAuthorization();

// Fortæller API - "Find alle controller-klasser og brug deres routes/endpoints"
app.MapControllers();

// Starter serveren
app.Run();