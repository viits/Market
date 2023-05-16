using Application.Interface;
using Application.Services;
using Domain.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//Adicionando banco de dados
var connectionString = builder.Configuration.GetConnectionString("DataConnection");
builder.Services.AddDbContext<MarketContext>(opts =>
    opts.UseLazyLoadingProxies().UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<ICategoria,CategoriaService>();
builder.Services.AddScoped<IProduto,ProdutoService>();
builder.Services.AddScoped<IMercado,MercadoService>();
builder.Services.AddScoped<EmailService,EmailService>();
builder.Services.AddScoped<TokenService,TokenService>();
builder.Services.AddScoped<IProdutoMercado, ProdutoMercadoService>();
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IUsuario, UsuarioService>();
builder.Services.AddScoped<ILista, ListaService>();
builder.Services.AddHttpContextAccessor();
// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt => {
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor colocar um token v�lido",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme, Id="Bearer"
                }
            },
            new string[]
            {

            }
        }
    });
});

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
