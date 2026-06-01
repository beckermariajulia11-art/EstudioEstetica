using EsteticaStudio.Application.Services;
using EsteticaStudio.Domain.Interfaces;
using EsteticaStudio.Infrastructure.Repositories;
using EsteticaStudio.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Repositórios singleton (memória vive enquanto o app rodar)
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
builder.Services.AddSingleton<IProfissionalRepository, ProfissionalRepository>();
builder.Services.AddSingleton<IProcedimentoRepository, ProcedimentoRepository>();
builder.Services.AddSingleton<IPacoteSessaoRepository, PacoteSessaoRepository>();
builder.Services.AddSingleton<ISessaoRepository, SessaoRepository>();

// Services com regras de negócio
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProfissionalService>();
builder.Services.AddScoped<ProcedimentoService>();
builder.Services.AddScoped<PacoteService>();
builder.Services.AddScoped<SessaoService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
