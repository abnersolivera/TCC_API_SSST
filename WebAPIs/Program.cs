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
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Text;
using Infrastructure;
using WebAPIs.Configurations;
using WebAPIs.Converters;
using WebAPIs.Models;
using WebAPIs.Token;

#endregion

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddIoC(builder.Configuration);

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



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
#endregion

#region Interface e Repositorio
builder.Services.AddScoped(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddScoped<IPessoa, RepositoryPessoa>();
builder.Services.AddScoped<IPrestador, RepositoryPrestador>();
builder.Services.AddScoped<IEmpresa, RepositoryEmpresa>();
builder.Services.AddScoped<IEndereco, RepositoryEndereco>();
builder.Services.AddScoped<IUnidade, RepositoryUnidade>();
builder.Services.AddScoped<IFuncionario, RepositoryFuncionario>();
builder.Services.AddScoped<ICargo, RepositoryCargo>();
builder.Services.AddScoped<ISetor, RepositorySetor>();
builder.Services.AddScoped<IExame, RepositoryExame>();
builder.Services.AddScoped<IRisco, RepositoryRisco>();
builder.Services.AddScoped<IUsuarioEmpresa, RepositoryUsuarioEmpresa>();
builder.Services.AddScoped<IPessoaEmpresa, RepositoryPessoaEmpresa>();
builder.Services.AddScoped<IPrestadorEmpresa, RepositoryPrestadorEmpresa>();
builder.Services.AddScoped<IEnderecoEmpresa, RepositoryEnderecoEmpresa>();
builder.Services.AddScoped<IEnderecoUnidade, RepositoryEnderecoUnidade>();
builder.Services.AddScoped<IFuncionarioExames, RepositoryFuncionarioExames>();
builder.Services.AddScoped<IUser, RepositoryUser>();
builder.Services.AddScoped<IFuncionarioRisco, RepositoryFuncionarioRisco>();
builder.Services.AddScoped<IAtendimento, RepositoryAtendimento>();
builder.Services.AddScoped<IAgendamento, RepositoryAgendamento>();
builder.Services.AddScoped<IAtendimentoEmpresa, RepositoryAtendimentoEmpresa>();
builder.Services.AddScoped<IAtendimentoExames, RepositoryAtendimentoExames>();
builder.Services.AddScoped<IAtendimentoFuncionario, RepositoryAtendimentoFuncionario>();
builder.Services.AddScoped<IAtendimentoRiscos, RepositoryAtendimentoRiscos>();
builder.Services.AddScoped<IUpload, RepositoryUpload>();
#endregion

#region Servico Dominio
builder.Services.AddScoped<IServicePessoa, ServicePessoa>();
builder.Services.AddScoped<IServicePrestador, ServicePrestador>();
builder.Services.AddScoped<IServiceEmpresa, ServiceEmpresa>();
builder.Services.AddScoped<IServiceEndereco, ServiceEndereco>();
builder.Services.AddScoped<IServiceUnidade, ServiceUnidade>();
builder.Services.AddScoped<IServiceFuncionario, ServiceFuncionario>();
builder.Services.AddScoped<IServiceCargo, ServiceCargo>();
builder.Services.AddScoped<IServiceSetor, ServiceSetor>();
builder.Services.AddScoped<IServiceExame, ServiceExame>();
builder.Services.AddScoped<IServiceRisco, ServiceRisco>();
builder.Services.AddScoped<IServiceUser, ServiceUser>();
builder.Services.AddScoped<IServiceAtendimento, ServiceAtendimento>();
builder.Services.AddScoped<IServiceAgendamento, ServiceAgendamento>();
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

            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = JwtSecurityKey.Create(configuration["Jwt:Key"] ?? string.Empty)
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
    cfg.CreateMap<AtendimentoGeral, AtendimentoGeralDTO>().ForMember(x => x.Empresa, x => x.MapFrom(em => em.Empresa))
                                                        .ForMember(x => x.Atendimento, x => x.MapFrom(a => a.Atendimento))
                                                        .ForMember(x => x.Funcionario, x => x.MapFrom(f => f.Funcionario))
                                                        .ForMember(x => x.Exames, x => x.MapFrom(ex => ex.Exames))
                                                        .ForMember(x => x.Riscos, x => x.MapFrom(r => r.Riscos))
                                                        .ReverseMap();

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
    cfg.CreateMap<Exame, ExameAtendimentoDTO>().ReverseMap();

    cfg.CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
    cfg.CreateMap<Funcionario, FuncionarioIdViewModel>().ReverseMap();
    cfg.CreateMap<FuncionarioExames, FuncionarioExamesViewModel>().ReverseMap();
    cfg.CreateMap<FuncionarioRisco, FuncionarioRiscoViewModel>().ReverseMap();
    cfg.CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
    cfg.CreateMap<FuncionarioEmpresaCargoSetor, FuncionarioEmpCarSerDTO>().ForMember(x => x.Empresa, x => x.MapFrom(e => e.EmpresaFun))
                                                                          .ForMember(x => x.Setor, x => x.MapFrom(s => s.SetorFun))
                                                                          .ForMember(x => x.Cargo, x => x.MapFrom(c => c.CargoFun))
                                                                          .ForMember(x => x.Unidade, x => x.MapFrom(u => u.UnidadeFun))
                                                                          .ReverseMap();
    cfg.CreateMap<FuncionarioAtendimento, FuncionarioAtendimentoDTO>().ForMember(x => x.Empresa, x => x.MapFrom(e => e.EmpresaFun))
                                                                      .ForMember(x => x.Setor, x => x.MapFrom(s => s.SetorFun))
                                                                      .ForMember(x => x.Cargo, x => x.MapFrom(c => c.CargoFun))
                                                                      .ForMember(x => x.Unidade, x => x.MapFrom(u => u.UnidadeFun))
                                                                      .ForMember(x => x.Atendimento, x => x.MapFrom(a => a.AtendimentoFun))
                                                                      .ForMember(x => x.Exame, x => x.MapFrom(ex => ex.ExameFun))
                                                                      .ForMember(x => x.Risco, x => x.MapFrom(r => r.RiscoFun))
                                                                      .ReverseMap();

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
    cfg.CreateMap<Risco, RiscoAtendimentoDTO>().ReverseMap();

    cfg.CreateMap<Setor, SetorViewModel>().ReverseMap();
    cfg.CreateMap<Setor, SetorIdViewModel>().ReverseMap();
    cfg.CreateMap<Setor, SetorDTO>().ReverseMap();
    cfg.CreateMap<Setor, SetorFuncionarioDTO>().ReverseMap();

    cfg.CreateMap<Unidade, UnidadeViewModel>().ReverseMap();
    cfg.CreateMap<Unidade, UnidadeIdViewModel>().ReverseMap();
    cfg.CreateMap<Unidade, UnidadeDTO>().ReverseMap();
    cfg.CreateMap<Unidade, UnidadeFuncionarioDTO>().ReverseMap();


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
app.UpdateMigrations();

app.Run();
