using DataAccessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;
using UserManagamentService.Models;
using UserManagamentService.Services;
using UserManagamentService.Services.Interfaces;
using WolfAPI.Mapping;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Models;
using WolfAPI.Services;
using WolfAPI.Services.Interfaces;
using AutoMapper;
using System.Text.Json.Serialization;
using System.Net.WebSockets;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
var environment = builder.Environment.EnvironmentName;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


builder.Services.AddDbContext<WolfDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<WolfDbContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(opts => opts.SignIn.RequireConfirmedEmail = true);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<MappingProfile>();
});
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeModelRepository, EmployeeModelRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IClientModelRepository, ClientModelRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IRequestModelRepository, RequestModelRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IClient_RequestRelashionshipModelRepository, Client_RequestRelashionshipModelRepository>();
builder.Services.AddScoped<IClient_RequestRelashionshipService, Client_RequestRelashionshipService>();
builder.Services.AddScoped<IActivityTypesModelRepository, ActivityTypesModelRepository>();
builder.Services.AddScoped<IActivityTypesService, ActivityTypesService>();
builder.Services.AddScoped<ITaskTypeModelRepository, TaskTypeModelRepository>();
builder.Services.AddScoped<ItaskTypesService, TaskTypeService>();
builder.Services.AddScoped<IActivityModelRespository, ActivityModelRespository>();
builder.Services.AddScoped<IAcitvityService, ActivityService>();
builder.Services.AddScoped<ItaskModelRepository, TaskModelRepository>();
builder.Services.AddScoped<ItaskServices, TaskService>();
builder.Services.AddScoped<IPlotModelRepository, PlotModelRespository>();
builder.Services.AddScoped<IPlotService, PlotService>();
builder.Services.AddScoped<IActivity_PlotRelashionshipModelRepository, Activity_PlotRelashionshipModelRepository>();
builder.Services.AddScoped<IActivity_PlotReleashionshipService, Activity_PlotRelashionshipService>();
builder.Services.AddScoped<IDocumentOfOwnershipModelRepository, DocumentOfOwnershipModelRepository>();
builder.Services.AddScoped<IDocumentOfOwnershipService, DocumentOfOwnershipService>();
builder.Services.AddScoped<IPlot_DocumentOfOwnershipRelashionshipModelRepository, Plot_DocumentOfOwnershipRelashionshipModelRepository>();
builder.Services.AddScoped<IPlot_DocumentOfOwnershipRelashionshipService, Plot_DocumentOfOwnershipRelashionshipService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IOwnerModelRepository, OwnerModelRepository>();
builder.Services.AddScoped<IDocumentOfOwnership_OwnerRelashionshipModelRepository, DocumentOfOwnership_OwnerRelashionshipModelRepository>();
builder.Services.AddScoped<IDocumentOfOwnership_OwnerRelashionshipService, DocumentOfOwnership_OwnerRelashionshipService>();
builder.Services.AddScoped<IDocumentPlot_DocumentOwnerRelashionshipModelRepository, DocumentPlot_DocumentOwnerRelashionshipModelRepository>();
builder.Services.AddScoped<IDocumentPlot_DocumentOwnerRelashionshipService, DocumentPlot_DocumentOwnerRelashionshipService>();
builder.Services.AddScoped<IPowerOfAttorneyDocumentService, PowerOfAttorneyDocumentService>();
builder.Services.AddScoped<IPowerOfAttorneyModelRepository, PowerOfAttorneyModelRepository>();
builder.Services.AddScoped<IFileModelRepository, FileModelRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IStarRequest_EmployeeRelashionshipModelRepository, StarRequest_EmployeeModelRepository>();
builder.Services.AddScoped<IStarRequest_EmployeeRelashionshipService, StarRequest_EmployeeRelashionshipService>();
builder.Services.AddScoped<IInvoiceModelRepository, InvoiceModelRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUserManagament, UserManagament>();

// Add WebSocket support
builder.Services.AddWebSockets(options =>
{
    options.KeepAliveInterval = TimeSpan.FromMinutes(2);
});
builder.Services.AddSingleton<IWebSocketService, WebSocketService>();


var config = builder.Configuration.GetSection("Kestrel:Endpoints:Https:Certificate");
var certPath = config["Path"];
var certPassword = config["Password"];

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(System.Net.IPAddress.Any, 5003, listenOptions => // HTTPS
    {
        listenOptions.UseHttps(certPath, certPassword);
    });
});

var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WolfDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting(); // Ensures that routing is enabled

app.UseAuthentication();
app.UseAuthorization();

// Enable WebSockets
app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.Map("/ws", async context =>
    {
        var webSocketService = context.RequestServices.GetRequiredService<IWebSocketService>();
        await webSocketService.HandleWebSocketAsync(context);
    });
});
app.Run();
