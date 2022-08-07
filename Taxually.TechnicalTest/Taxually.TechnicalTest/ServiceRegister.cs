using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Services;
using Taxually.TechnicalTest.Services.VatProviders;

namespace Taxually.TechnicalTest
{
    public static class ServiceRegister
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ITaxuallyHttpClient, TaxuallyHttpClient>();
            services.AddSingleton<ITaxuallyQueueClient, TaxuallyQueueClient>();
            services.AddSingleton<ICsvService, CsvService>();
            services.AddSingleton<IXmlService, XmlService>();
            services.AddSingleton<IVatRegistrationProviderFactory, VatRegistrationProviderFactory>();

            services.AddTransient<UKVatRegistrationProvider>();
            services.AddTransient<IVatRegistrationProvider, UKVatRegistrationProvider>(x => x.GetService<UKVatRegistrationProvider>());
            services.AddTransient<GermanyVatRegistrationProvider>();
            services.AddTransient<IVatRegistrationProvider, GermanyVatRegistrationProvider>(x => x.GetService<GermanyVatRegistrationProvider>());
            services.AddTransient<FranceVatRegistrationProvider>();
            services.AddTransient<IVatRegistrationProvider, FranceVatRegistrationProvider>(x => x.GetService<FranceVatRegistrationProvider>());

        }
    }
}
