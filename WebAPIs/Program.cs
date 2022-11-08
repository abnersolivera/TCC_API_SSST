#region Using
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Entities.Entities.Atendimentos;
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
#endregion

var builder = WebApplication.CreateBuilder(args);

#region ServicesContainer
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region ConfigService
builder.Services.AddDbContext<ContextBase>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
#endregion

#region Interface e Repositorio
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
builder.Services.AddSingleton<IUser, RepositoryUser>();
builder.Services.AddSingleton<IFuncionarioRisco, RepositoryFuncionarioRisco>();
builder.Services.AddSingleton<IAtendimento, RepositoryAtendimento>();
builder.Services.AddSingleton<IAgendamento, RepositoryAgendamento>();
builder.Services.AddSingleton<IAtendimentoEmpresa, RepositoryAtendimentoEmpresa>();
builder.Services.AddSingleton<IAtendimentoExames, RepositoryAtendimentoExames>();
builder.Services.AddSingleton<IAtendimentoFuncionario, RepositoryAtendimentoFuncionario>();
builder.Services.AddSingleton<IAtendimentoRiscos, RepositoryAtendimentoRiscos>();
#endregion

#region Serviço Dominio
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
builder.Services.AddSingleton<IServiceUser, ServiceUser>();
builder.Services.AddSingleton<IServiceAtendimento, ServiceAtendimento>();
builder.Services.AddSingleton<IServiceAgendamento, ServiceAgendamento>();
#endregion

#region JWT
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
#endregion

#region AutoMapper
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
    cfg.CreateMap<Prestador, PrestadorViewModel>().ReverseMap();
    cfg.CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
    cfg.CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
    cfg.CreateMap<Unidade, UnidadeViewModel>().ReverseMap();
    cfg.CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
    cfg.CreateMap<Setor, SetorViewModel>().ReverseMap();
    cfg.CreateMap<Cargo, CargoViewModel>().ReverseMap();
    cfg.CreateMap<Exame, ExameViewModel>().ReverseMap();
    cfg.CreateMap<Risco, RiscoViewModel>().ReverseMap();
    cfg.CreateMap<UsuarioEmpresa, UsuarioEmpresaViewModel>().ReverseMap();
    cfg.CreateMap<PessoaEmpresa, PessoaEmpresaViewModel>().ReverseMap();
    cfg.CreateMap<PrestadorEmpresa, PrestadorEmpresaViewModel>().ReverseMap();
    cfg.CreateMap<EnderecoEmpresa, EnderecoEmpresaViewModel>().ReverseMap();
    cfg.CreateMap<EnderecoUnidade, EnderecoUnidadeViewModel>().ReverseMap();
    cfg.CreateMap<FuncionarioExames, FuncionarioExamesViewModel>().ReverseMap();
    cfg.CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
    cfg.CreateMap<Pessoa, PessoaIdViewModel>().ReverseMap();
    cfg.CreateMap<Empresa, EmpresaIdViewModel>().ReverseMap();
    cfg.CreateMap<Cargo, CargoIdViewModel>().ReverseMap();
    cfg.CreateMap<Endereco, EnderecoIdViewModel>().ReverseMap();
    cfg.CreateMap<Exame, ExameIdViewModel>().ReverseMap();
    cfg.CreateMap<Funcionario, FuncionarioIdViewModel>().ReverseMap();
    cfg.CreateMap<Prestador, PrestadorIdViewModel>().ReverseMap();
    cfg.CreateMap<Unidade, UnidadeIdViewModel>().ReverseMap();
    cfg.CreateMap<Setor, SetorIdViewModel>().ReverseMap();
    cfg.CreateMap<Risco, RiscoIdViewModel>().ReverseMap();
    cfg.CreateMap<FuncionarioRisco, FuncionarioRiscoViewModel>().ReverseMap();
    cfg.CreateMap<ExameDetails, ExameDetailsViewModel>().ReverseMap()/*.ForMember(edv => edv.ExameViewModel, m => m.MapFrom(ed => ed.Exame)).ForMember(edv => edv.ExameViewModel, m => m.MapFrom(ed => ed.Details))*/;
    cfg.CreateMap<Atendimento, AtendimentoViewModel>().ReverseMap();
    cfg.CreateMap<Atendimento, AtendimentoIdViewModel>().ReverseMap();
    cfg.CreateMap<Agendamento, AgendamentoViewModel>().ReverseMap();
    cfg.CreateMap<Agendamento, AgendamentoIdViewModel>().ReverseMap();
    cfg.CreateMap<AtendimentoEmpresa, AtendimentoEmpresaViewModel>().ReverseMap();
    cfg.CreateMap<AtendimentoFuncionario, AtendimentoFuncionarioViewModel>().ReverseMap();
    cfg.CreateMap<AtendimentoExames, AtendimentoExamesViewModel>().ReverseMap();
    cfg.CreateMap<AtendimentoRiscos, AtendimentoRiscosViewModel>().ReverseMap();
});


IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
#endregion

#region ConfigureHTTP
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
#endregion

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
