using DataAccess;
using DataAccess.Contracts;
using Mapping;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Contracts;
using TicketTracker.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IReplyService, ReplyService>();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IReplyRepository, ReplyRepository>();

builder.Services.AddDbContext<TicketDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDbContext<ReplyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(
    typeof(TicketProfile),
    typeof(ReplyProfile)
);

builder.Services.AddSwaggerGen();

var origins = builder.Configuration.GetSection("AllowedHosts").Get<string[]>();
if (origins == null)
    throw new ApplicationException("Allowed origins are not specified");

builder.Services.AddCors(options => options.AddPolicy("default", 
    policy => policy
        .WithOrigins(origins)
        .AllowCredentials()
        .WithHeaders("Content-Type")
        .WithMethods("GET", "POST", "PUT", "DELETE"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseCors("default");

app.UseAuthorization();

app.MapControllers();

app.Run();