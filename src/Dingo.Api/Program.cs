using Dingo.Api.Persistence;
using Dingo.Api.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
{
    //configure Services (DI)
    builder.Services.AddControllers();
    builder.Services.AddSingleton<UserService>();
    builder.Services.AddSingleton<LikeService>();
    builder.Services.AddSingleton<ArticleService>();
    builder.Services.AddSingleton<IArticleRepository, MongoArticleRepository>();
    builder.Services.AddSingleton<ILikeRepository, MongoLikeRepository>();
    builder.Services.AddSingleton<IMongoClient>(sp =>
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
        var connectionString = builder.Configuration.GetConnectionString("MongoConnectionString");
        return new MongoClient(connectionString);
    });
    builder.Services.AddSingleton(sp =>
    {
        var client = sp.GetRequiredService<IMongoClient>();
        var database = builder.Configuration.GetSection("MongoDatabaseName").Value!;
        return client.GetDatabase(database);
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


var app = builder.Build();
{
    //Configure request pipeline

    app.MapControllers();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}

app.UseHttpsRedirection();

app.Run();

