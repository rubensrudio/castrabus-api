using CastraBus.Application.Services.Concret;
using CastraBus.Common.Singleton;
using CastraBus.Infra.Data.Context;
using CastraBus.Infra.IoC.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using Serilog;
using CastraBus.Common.Extensions;
using CastraBus.Common.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using DinkToPdf.Contracts;
using DinkToPdf;
using CastraBus.Common.AssemblyDll;

var builder = WebApplication.CreateBuilder(args);

SerilogExtension.AddSerilogApi(builder.Configuration);
builder.Host.UseSerilog(Log.Logger);

Log.Information("Inicializando Api CastraBus");

builder.Services.AddControllers().AddJsonOptions(op =>
{
    //op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    op.JsonSerializerOptions.MaxDepth = 0;
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddResponseCompression(op =>
{
    op.Providers.Add<BrotliCompressionProvider>();
    op.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<BrotliCompressionProviderOptions>(op =>
{
    op.Level = CompressionLevel.Fastest;
});

builder.Services.Configure<GzipCompressionProviderOptions>(op =>
{
    op.Level = CompressionLevel.Fastest;
});

var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
var ibgeOptions = builder.Configuration.GetSection("IbgeOptions").Get<IbgeOptions>();
var googleOptions = builder.Configuration.GetSection("GoogleOptions").Get<GoogleOptions>();
var facebookOptions = builder.Configuration.GetSection("FacebookOptions").Get<FacebookOptions>();
var kafkaOptions = builder.Configuration.GetSection("KafkaOptions").Get<KafkaOptions>();
var natsOptions = builder.Configuration.GetSection("NatsOptions").Get<NatsOptions>();

builder.Services.AddDbContext<ApplicationDbContext>(
    op => op.UseNpgsql(connectionString)
);

builder.Services.AddSingleton(jwtOptions);
builder.Services.AddSingleton(ibgeOptions);
builder.Services.AddSingleton(googleOptions);
builder.Services.AddSingleton(facebookOptions);
builder.Services.AddSingleton(kafkaOptions);
builder.Services.AddSingleton(natsOptions);

var contextLoad = new CustomAssemblyLoadContext();
contextLoad.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "Config", "Resources", "libs", "libwkhtmltox.dll"));
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

builder.Services.AddCors(op =>
{
    op.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200/")
                                                 .AllowAnyOrigin()
                                                 .AllowAnyMethod()
                                                 .AllowAnyHeader());
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddService(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    byte[] signingKeyBytes = Encoding.UTF8.GetBytes(jwtOptions.SigningKey);

    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
    };
});
builder.Services.AddAuthorization();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Castra Bus API",
        Version = "v1",
        Description = "Api de suporte ao Site Castra Bus.",
        Contact = new OpenApiContact
        {
            Name = "Castra Bus",
            Email = ""
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Cabeçalho de Autorização JWT está usando o esquema Bearer \r\n\r\n Digite 'Bearer' antes de colocar Token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<String>()
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

#endregion

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestSerilLogMiddleware>();

//Inicializando o banco de Dados
using (var scope = app.Services.CreateScope())
{
    var ser = scope.ServiceProvider;
    var context = ser.GetRequiredService<ApplicationDbContext>();   
    DataServiceAsync.Initialize(context);

    var configuration = ser.GetRequiredService<IConfiguration>();
    var hostEnvironment = ser.GetRequiredService<IHostEnvironment>();

    //var t = new PdfServiceAsync(configuration, hostEnvironment);
    //t.LoadJsonsMedicamentos(context).Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Castra Bus");
        c.DocExpansion(DocExpansion.None);
    });
}

app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .SetIsOriginAllowed(origin => true));

app.UseHealthChecks("/status-text");
app.UseHealthChecks("/status-json",
    new HealthCheckOptions()
    {
        ResponseWriter = async (context, report) =>
        {
            var result = JsonSerializer.Serialize(new { currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), statusApplication = report.Status.ToString() });
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(result);
        }
    }
);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();