#region Using
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Domain.Services.Utils;
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
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using WebAPIs.Converters;
using WebAPIs.Models;
using WebAPIs.Token;
#endregion

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name).DateTimeFormat;

#region ServicesContainer
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => 
{ 
    options.JsonSerializerOptions.Converters.Add(new DateConverter()); 
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(op =>
{
    op.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SSST",
        Description = "Api SSST"
    });
});
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
builder.Services.AddSingleton<IUpload, RepositoryUpload>();
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
    cfg.CreateMap<DateTime, string>().ConvertUsing<ConvertDateTime>();

    cfg.CreateMap<Agendamento, AgendamentoViewModel>().ReverseMap();
    cfg.CreateMap<Agendamento, AgendamentoIdViewModel>().ReverseMap();
    cfg.CreateMap<Agendamento, AgendamentoDTO>().ReverseMap();

    cfg.CreateMap<Atendimento, AtendimentoViewModel>().ReverseMap();
    cfg.CreateMap<Atendimento, AtendimentoIdViewModel>().ReverseMap();
    cfg.CreateMap<AtendimentoEmpresa, AtendimentoEmpresaViewModel>().ReverseMap();
    cfg.CreateMap<AtendimentoFuncionario, AtendimentoFuncionarioViewModel>().ReverseMap();
    cfg.CreateMap<AtendimentoExames, AtendimentoExamesViewModel>().ReverseMap();
    cfg.CreateMap<AtendimentoRiscos, AtendimentoRiscosViewModel>().ReverseMap();
    cfg.CreateMap<Atendimento, AtendimentoDTO>().ReverseMap();
    cfg.CreateMap<AtendimentoGeral, AtendimentoGerals>().ForMember(x => x.Empresa, x => x.MapFrom(em => em.Empresa))
                                                        .ForMember(x => x.Atendimento, x => x.MapFrom(a => a.Atendimento))
                                                        .ForMember(x => x.Funcionario, x => x.MapFrom(f => f.Funcionario))
                                                        .ForMember(x => x.Exames, x => x.MapFrom(ex => ex.Exames))
                                                        .ForMember(x => x.Riscos, x => x.MapFrom(r => r.Riscos))
                                                        .ReverseMap();
    cfg.CreateMap<AtendimentoGeral, AtendimentoViewModel>().ReverseMap();

    cfg.CreateMap<Cargo, CargoViewModel>().ReverseMap();
    cfg.CreateMap<Cargo, CargoIdViewModel>().ReverseMap();
    cfg.CreateMap<Cargo, CargoDTO>().ReverseMap();
    cfg.CreateMap<Cargo, CargoFuncionarioDTO>().ReverseMap();

    cfg.CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
    cfg.CreateMap<Empresa, EmpresaIdViewModel>().ReverseMap();
    cfg.CreateMap<Empresa, EmpresaDTO>().ReverseMap();
    cfg.CreateMap<Empresa, EmpresaFuncionarioDTO>().ReverseMap();

    cfg.CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
    cfg.CreateMap<Endereco, EnderecoIdViewModel>().ReverseMap();
    cfg.CreateMap<EnderecoEmpresa, EnderecoEmpresaViewModel>().ReverseMap();
    cfg.CreateMap<EnderecoUnidade, EnderecoUnidadeViewModel>().ReverseMap();
    cfg.CreateMap<Endereco, EnderecoDTO>().ReverseMap();

    cfg.CreateMap<Exame, ExameViewModel>().ReverseMap();
    cfg.CreateMap<Exame, ExameIdViewModel>().ReverseMap();
    cfg.CreateMap<ExameDetails, ExameDetailsViewModel>().ForMember(x => x.ExameViewModel, x => x.MapFrom(e => e.Exame)).ReverseMap();
    cfg.CreateMap<Exame, ExameDTO>().ReverseMap();

    cfg.CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
    cfg.CreateMap<Funcionario, FuncionarioIdViewModel>().ReverseMap();
    cfg.CreateMap<FuncionarioExames, FuncionarioExamesViewModel>().ReverseMap();
    cfg.CreateMap<FuncionarioRisco, FuncionarioRiscoViewModel>().ReverseMap();
    cfg.CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
    cfg.CreateMap<FuncionarioEmpresaCargoSetor, FuncionarioEmpCarSerDTO>().ForMember(x => x.Empresa, x => x.MapFrom(e => e.EmpresaFun)).ForMember(x => x.Setor, x => x.MapFrom(s => s.SetorFun)).ForMember(x => x.Cargo, x => x.MapFrom(c => c.CargoFun)).ReverseMap();

    cfg.CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
    cfg.CreateMap<Pessoa, PessoaIdViewModel>().ReverseMap();
    cfg.CreateMap<PessoaEmpresa, PessoaEmpresaViewModel>().ReverseMap();
    cfg.CreateMap<Pessoa, PessoaDTO>().ReverseMap();

    cfg.CreateMap<Prestador, PrestadorViewModel>().ReverseMap();
    cfg.CreateMap<Prestador, PrestadorIdViewModel>().ReverseMap();
    cfg.CreateMap<PrestadorEmpresa, PrestadorEmpresaViewModel>().ReverseMap();
    cfg.CreateMap<Prestador, PrestadorDTO>().ReverseMap();

    cfg.CreateMap<Risco, RiscoViewModel>().ReverseMap();
    cfg.CreateMap<Risco, RiscoIdViewModel>().ReverseMap();
    cfg.CreateMap<Risco, RiscoDTO>().ReverseMap();

    cfg.CreateMap<Setor, SetorViewModel>().ReverseMap();
    cfg.CreateMap<Setor, SetorIdViewModel>().ReverseMap();
    cfg.CreateMap<Setor, SetorDTO>().ReverseMap();
    cfg.CreateMap<Setor, SetorFuncionarioDTO>().ReverseMap();

    cfg.CreateMap<Unidade, UnidadeViewModel>().ReverseMap();
    cfg.CreateMap<Unidade, UnidadeIdViewModel>().ReverseMap();
    cfg.CreateMap<Unidade, UnidadeDTO>().ReverseMap();


    cfg.CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
    cfg.CreateMap<UsuarioEmpresa, UsuarioEmpresaViewModel>().ReverseMap();
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
