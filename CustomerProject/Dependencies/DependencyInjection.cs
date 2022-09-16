using Customer.Application;
using Customer.Application.Shared.Common.Interfaces;
using Customer.Application.Shared.Interfaces;
using Customer.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProject.Dependencies
{
    public static class DependencyInjection
    {
        private static IServiceCollection _services;

        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            _services = services;

            //_services.AddScoped<IRepository, Repository>();
            _services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            _services.AddTransient<ITestAppService, TestAppservice>();
            _services.AddTransient<ICustomerAppService, CustomerAppService>();
            _services.AddTransient<ICustomerTypeAppService, CustomerTypeAppService>();

            return _services;
        }
    }
}
