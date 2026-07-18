var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register our service
// Whenever a controller needs CurrencyConverterService, create and provide one.
builder.Services.AddScoped<CurrencyConverter.API.Services.CurrencyConverterService>();
builder.Services.AddScoped<CurrencyConverter.API.Converters.EnglishConverter>();
builder.Services.AddScoped<CurrencyConverter.API.Converters.GermanConverter>();

var app = builder.Build();
app.UseCors("ReactPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();