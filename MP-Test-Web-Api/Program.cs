using Microsoft.EntityFrameworkCore;
using MPTWA_Application.Interfaces;
using MPTWA_Domain.Entities;
using MPTWA_Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region EF
builder.Services.AddDbContext<LogContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("MainDB"),
        assembly =>
        {
            assembly.MigrationsAssembly("MPTWA-Infrastructure");
            assembly.MigrationsHistoryTable("__MPTWAigrationsHistory","public");
        });
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IRepository<LogContext>, Repository<LogContext>>();

#endregion

#region DISerices

builder.Services.AddScoped<INewsService,NewsService>();
builder.Services.AddScoped<INewsServiceFromPackage,NewsServiceFromPackage>();
builder.Services.AddScoped<IVowelCountService,VowelCountService>();
builder.Services.AddScoped<ILogToDbService,LogToDbService>();

#endregion

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
