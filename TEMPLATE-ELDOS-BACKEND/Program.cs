using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TEMPLATE_ELDOS_BACKEND.App;
using TEMPLATE_ELDOS_BACKEND.Domain.Interfaces;
using TEMPLATE_ELDOS_BACKEND.Infrastructure.Data;
using TEMPLATE_ELDOS_BACKEND.Infrastructure.Services;
using TEMPLATE_ELDOS_BACKEND.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.PropertyNamingPolicy = null;
    opts.JsonSerializerOptions.ReferenceHandler = null;
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddDbContext<AppDbContext>(q => q.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")), ServiceLifetime.Scoped);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
        o.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                // If the request is for our hub...
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    (path.StartsWithSegments("/notificationHub")))
                {
                    // Read the token out of the query string
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });
//builder.Services.AddRateLimiter(options =>
//{
//    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
//    options.AddConcurrencyLimiter("concurrency", options =>
//    {
//        options.PermitLimit = 10;
//        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//        options.QueueLimit = 5;
//    });
//});

builder.Services.AddAuthorization();
builder.Services.AddCors((o => o.AddPolicy("LowCorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
})));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IEMailService, EMailService>();
builder.Services.AddScoped<IImportDataService, ImportDataService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("LowCorsPolicy");
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseWebSockets();
app.MapControllers();
app.MapHub<NotificationHub>("/notificationHub");
app.Run();
