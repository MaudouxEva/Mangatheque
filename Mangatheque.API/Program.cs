using System.Data.Common;
using Mangatheque.BLL.Interfaces;
using Mangatheque.BLL.Services;
using Mangatheque.DAL.Interfaces;
using Mangatheque.DAL.Repositories;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuration de l'injection de dépendance pour fournir une nouvelle instance de connexion, en utilisant la chaine de connexion spécifiée dans la config de l'app
// AddTranscient : enregistre un service transitoire pour DbConnection. Un service transitoire est créé chaque fois qu'il est demandé.
builder.Services.AddTransient<DbConnection>(service =>
{
    // Récupère la chaine de connexion à la DB à partir de la config de l'app. GetConnectionString utilise la clé Défault pour obtenir la chaine de connexion (! : la valeur ne sera pas nulle)
    string connectionString = builder.Configuration.GetConnectionString("Default")!;
    // Crée une nouvelle instance de SqlConnection utilisée pour les connexions ) la DB
   return new SqlConnection(connectionString);
});

// Toutes les dépendances sont configurées un en seul endroit pour la gestion et modification des dépendances

// Injection des services de la BLL dans le conteneur d'injection de l'app
// scoped (cycle de vie) => une nouvelle instance du service est créée pour chaque requete HTTP. Utile pour les services qui doivent mainteant un état cohérent pendant toute la durée de la requete

builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IVolumeService, VolumeService>();

// Injection des repositories de la DAL dans le conteneur d'injection de l'app
// Nouvelle instance du repository est créée pour chaque requete HTTP
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IVolumeRepository, VolumeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();