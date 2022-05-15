using LupitBackEnd.Models;
using LupitBackEnd.Repositories;
using LupitBackEnd.Repositories.Jogadores;
using LupitBackEnd.Repositories.Times;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LupitBackEnd.Utils
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddTransient<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
        
            services.AddScoped<ITimesRepository, TimesRepository>();
            services.AddScoped<IJogadoresRepository, JogadoresRepository>();
            services.AddScoped<IDataBaseConnection, DataBaseConnection>();
        }
    }
}
