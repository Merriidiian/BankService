using BankService;
using BankService.GraphQL.Schemas;
using BankService.Repositories;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BankConnection")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDataRepository, DataRepository>();
builder.Services.AddScoped<ISchema, BankSchema>();
builder.Services.AddGraphQL(options => { options.EnableMetrics = true; }).AddSystemTextJson();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLAltair();
}

//app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseGraphQL<ISchema>();
app.MapControllers();
app.Run();