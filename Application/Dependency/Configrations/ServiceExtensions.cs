
using Application.Commons.EmailConfigurations;
using Application.Repository.Permission;

using Application.Repository;
using Core.Interfaces.UserLogin;
using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces.Settings;
using Application.Repository.Settings;
using Application.Repository.UserLogin;

namespace Application.Dependency.Configrations
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", x => x.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin());

            });
        }
        public static void ConfigureScoped(this IServiceCollection services)
        {
            #region Settings Interface
            services.AddScoped<IAgent, AgentRepository>();
            services.AddScoped<IBranch_Gallary, Branch_GallaryRepository>();
            services.AddScoped<ICatogery, CatogeryRepository>();
            services.AddScoped<IItem, ItemRepository>();
            services.AddScoped<ISale, SaleRepository>();
            services.AddScoped<ISalesInformation, SaleInformationRepository>();
            services.AddScoped<ISattelment, SattelmentRepository>();
            services.AddScoped<IStoreQuantities, StoreQuantitiesRepository>();
            services.AddScoped<IStoreReturned, StoreReturnedRepository>();
            services.AddScoped<IStories, StoriesRopsitory>();
            services.AddScoped<ISupliers, SupliersRepository>();
            services.AddScoped<ISuppliment, SupplimentRepository>();
            services.AddScoped<ISupplimentInformation, SupplimentInformationRepository>();
            services.AddScoped<IUnit, UnitRepository>();
            services.AddScoped<IVauchers, VauchersRepository>();
           
            #endregion

            #region User Login and 
             services.AddScoped<IUserlogin, UserloginRepository>();
            #endregion

            #region Email
            services.AddScoped<IEmailSender, EmailSender>();
            #endregion
        }
    }
}
