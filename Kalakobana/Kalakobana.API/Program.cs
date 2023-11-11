using Kalakobana.API.Infrastructure.Exceptions;
using Kalakobana.API.Infrastructure.Extensions;
using Kalakobana.Persistence.DataContext;
using Kalakobana.Persistence.Store;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Serilog
Log.Logger = new LoggerConfiguration()
                   .WriteTo.File("critical.txt", rollingInterval: RollingInterval.Day)
                   .CreateLogger();
#endregion
#region Sql Connection
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
builder.Services.AddDbContext<KalakobanaDbContext>(options => 
                                                  options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnectionString))), ServiceLifetime.Scoped);
#endregion
#region AddServices
builder.Services.AddServices();
#endregion
#region MediatR
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


#region App Run
try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex.Message, ex);
}
finally
{
    Log.CloseAndFlush();
}

#endregion