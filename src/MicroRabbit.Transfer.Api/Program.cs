using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.IoC;
using Microrabbit.Transfer.Data.Context;
using Microrabbit.Transfer.Domain.EventHandler;
using Microrabbit.Transfer.Domain.Events;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RegisterServices(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservice API v1"); });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ConfigureEventBus(app);

app.Run();

static void ConfigureEventBus(IApplicationBuilder webApplication)
{
    var eventBus = webApplication.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Suscribe<TransferCreatedEvent, TransferEventHandler>();
}

void RegisterServices(IServiceCollection builderServices)
{
    builderServices.AddDbContext<TransferDBContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    builderServices.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

    DepedencyContainer.RegisterServices(builderServices);
}