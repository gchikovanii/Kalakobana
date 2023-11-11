
using Kalakobana.API.Infrastructure.Extensions;
using Kalakobana.Infrastructure.Repositories.Base;
using Kalakobana.Persistence.DataContext;
using Kalakobana.Persistence.Store;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Sql Connection
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
builder.Services.AddDbContext<KalakobanaDbContext>(options => 
                                                  options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnectionString))));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
