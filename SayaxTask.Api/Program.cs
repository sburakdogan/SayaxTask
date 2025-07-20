using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Helper;
using SayaxTask.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMeterService, MeterService>();
builder.Services.AddScoped<IExcelReaderService, ExcelReaderService>();
builder.Services.AddScoped<IPriceInfoService, PriceInfoService>();

builder.Services.AddScoped<ICalculationService, S1CalculationService>();

var filePath = Path.Combine(builder.Environment.ContentRootPath, "Sayax_Task_Veri.xlsx");
builder.Services.AddSingleton(sp =>
{
    return new ExcelReaderHelper(filePath);
});
builder.Services.AddSingleton<ReflectionHelper>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
