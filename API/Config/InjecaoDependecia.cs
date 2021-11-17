using API.Token;
using Business.Interfaces.Notification;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Notifications;
using Business.Services;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace API.Config
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<ILeituristaRepository, LeituristaRepository>();
            services.AddScoped<ILeituristaService, LeituristaService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
            services.AddScoped<IOcorrenciaService, OcorrenciaService>();
            services.AddScoped<ILeituraRepository, LeituraRepository>();
            services.AddScoped<ILeituraService, LeituraService>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
