using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using JwtModels;

namespace JwtAuthWebAPI
{
    public static class IOCConfiguration
    {
        public static IServiceCollection IOCRegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
