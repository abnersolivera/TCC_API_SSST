using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Entities.Entities.Cargos;
using Entities.Entities.Empresas;
using Entities.Entities.Endereco;
using Entities.Entities.Exames;
using Entities.Entities.Funcionarios;
using Entities.Entities.Pessoas;
using Entities.Entities.Prestadores;
using Entities.Entities.Riscos;
using Entities.Entities.Setores;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPIs.Models;
using WebAPIs.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ConfigService
builder.Services.AddDbContext<ContextBase>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Interface e Repositorio
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IPessoa, RepositoryPessoa>();
builder.Services.AddSingleton<IPrestador, RepositoryPrestador>();
builder.Services.AddSingleton<IEmpresa, RepositoryEmpresa>();
builder.Services.AddSingleton<IEndereco, RepositoryEndereco>();
builder.Services.AddSingleton<IUnidade, RepositoryUnidade>();
builder.Services.AddSingleton<IFuncionario, RepositoryFuncionario>();
builder.Services.AddSingleton<ICargo, RepositoryCargo>();
builder.Services.AddSingleton<ISetor, RepositorySetor>();
builder.Services.AddSingleton<IExame, RepositoryExame>();
builder.Services.AddSingleton<IRisco, RepositoryRisco>();
builder.Services.AddSingleton<IUsuarioEmpresa, RepositoryUsuarioEmpresa>();
builder.Services.AddSingleton<IPessoaEmpresa, RepositoryPessoaEmpresa>();
builder.Services.AddSingleton<IPrestadorEmpresa, RepositoryPrestadorEmpresa>();
builder.Services.AddSingleton<IEnderecoEmpresa, RepositoryEnderecoEmpresa>();
builder.Services.AddSingleton<IEnderecoUnidade, RepositoryEnderecoUnidade>();
builder.Services.AddSingleton<IFuncionarioExames, RepositoryFuncionarioExames>();

//Serviço Dominio
builder.Services.AddSingleton<IServicePessoa, ServicePessoa>();
builder.Services.AddSingleton<IServicePrestador, ServicePrestador>();
builder.Services.AddSingleton<IServiceEmpresa, ServiceEmpresa>();
builder.Services.AddSingleton<IServiceEndereco, ServiceEndereco>();
builder.Services.AddSingleton<IServiceUnidade, ServiceUnidade>();
builder.Services.AddSingleton<IServiceFuncionario, ServiceFuncionario>();
builder.Services.AddSingleton<IServiceCargo, ServiceCargo>();
builder.Services.AddSingleton<IServiceSetor, ServiceSetor>();
builder.Services.AddSingleton<IServiceExame, ServiceExame>();
builder.Services.AddSingleton<IServiceRisco, ServiceRisco>();

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "SSST.Securiry.Bearer",
            ValidAudience = "SSST.Securiry.Bearer",
            IssuerSigningKey = JwtSecurityKey.Create("G4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ")
        };

        option.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return Task.CompletedTask;
            }
        };
    });

//AutoMapper
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<PessoaViewModel, Pessoa>();
    cfg.CreateMap<Pessoa, PessoaViewModel>();
    cfg.CreateMap<PrestadorViewModel, Prestador>();
    cfg.CreateMap<Prestador, PrestadorViewModel>();
    cfg.CreateMap<EmpresaViewModel, Empresa>();
    cfg.CreateMap<Empresa, EmpresaViewModel>();
    cfg.CreateMap<EnderecoViewModel, Endereco>();
    cfg.CreateMap<Endereco, EnderecoViewModel>();
    cfg.CreateMap<UnidadeViewModel, Unidade>();
    cfg.CreateMap<Unidade, UnidadeViewModel>();
    cfg.CreateMap<FuncionarioViewModel, Funcionario>();
    cfg.CreateMap<Funcionario, FuncionarioViewModel>();
    cfg.CreateMap<SetorViewModel, Setor>();
    cfg.CreateMap<Setor, SetorViewModel>();
    cfg.CreateMap<CargoViewModel, Cargo>();
    cfg.CreateMap<Cargo, CargoViewModel>();
    cfg.CreateMap<ExameViewModel, Exame>();
    cfg.CreateMap<Exame, ExameViewModel>();
    cfg.CreateMap<RiscoViewModel, Risco>();
    cfg.CreateMap<Risco, RiscoViewModel>();
    cfg.CreateMap<UsuarioEmpresaViewModel, UsuarioEmpresa>();
    cfg.CreateMap<UsuarioEmpresa, UsuarioEmpresaViewModel>();
    cfg.CreateMap<PessoaEmpresaViewModel, PessoaEmpresa>();
    cfg.CreateMap<PessoaEmpresa, PessoaEmpresaViewModel>();
    cfg.CreateMap<PrestadorEmpresaViewModel, PrestadorEmpresa>();
    cfg.CreateMap<PrestadorEmpresa, PrestadorEmpresaViewModel>();
    cfg.CreateMap<EnderecoEmpresaViewModel, EnderecoEmpresa>();
    cfg.CreateMap<EnderecoEmpresa, EnderecoEmpresaViewModel>();
    cfg.CreateMap<EnderecoUnidadeViewModel, EnderecoUnidade>();
    cfg.CreateMap<EnderecoUnidade, EnderecoUnidadeViewModel>();
    cfg.CreateMap<FuncionarioExamesViewModel, FuncionarioExames>();
    cfg.CreateMap<FuncionarioExames, FuncionarioExamesViewModel>();
});

IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment() || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var urlDev = "https://dominiodocliente.com.br";
//var urlHML = "https://dominiodocliente2.com.br";
//var urlPROD = "https://dominiodocliente3.com.br";

//app.UseCors(b => b.WithOrigins(urlDev, urlHML, urlPROD));

var devClient = "https://ssstdev.azurewebsites.net";

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader().WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
