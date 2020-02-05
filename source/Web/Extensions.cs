using Architecture.Application;
using Architecture.Database;
using Architecture.Infra;
using DotNetCore.AspNetCore;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Architecture.Web
{
    public static class Extensions
    {
        public static void AddClassesMatchingInterfaces(this IServiceCollection services)
        {
            services.AddClassesMatchingInterfaces(typeof(IUserApplicationService).Assembly);
            services.AddClassesMatchingInterfaces(typeof(IUnitOfWork).Assembly);
            services.AddClassesMatchingInterfaces(typeof(ISignInService).Assembly);
        }

        public static void AddContext(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString(nameof(Context));
            services.AddDbContextMigrate<Context>(options => options.UseSqlServer(connectionString));
        }

        public static void AddSecurity(this IServiceCollection services)
        {
            services.AddHash(10000, 128);
            services.AddJsonWebToken(Guid.NewGuid().ToString(), TimeSpan.FromHours(12));
            services.AddAuthenticationJwtBearer();
        }

        public static void AddSpa(this IServiceCollection services)
        {
            services.AddSpaStaticFiles("Frontend/dist");
        }

        public static void UseSpa(this IApplicationBuilder application)
        {
            application.UseSpaAngularServer("Frontend", "development");
        }
    }
}
