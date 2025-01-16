using Hx.Abp.DataQualityInspection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Host.UseAutofac();  //Add this line

await builder.AddApplicationAsync<AppModule>();

var app = builder.Build();

await app.InitializeApplicationAsync();
await app.RunAsync();