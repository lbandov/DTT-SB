using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Services.VatProviders;

namespace Taxually.TechnicalTest.Services
{
    public class VatRegistrationProviderFactory : IVatRegistrationProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        private static readonly Dictionary<string, Type> _registeredProviders = new() {
            {"GB", typeof(UKVatRegistrationProvider) },
            {"DE", typeof(GermanyVatRegistrationProvider) },
            {"FR", typeof(FranceVatRegistrationProvider) }
        };
        public VatRegistrationProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IVatRegistrationProvider GetProvider(string countryCode)
        {
            var isRegistered = _registeredProviders.TryGetValue(countryCode, out var providerType);
            if(!isRegistered)
            {
                throw new BadHttpRequestException("Country not supported");
            }

            return (IVatRegistrationProvider)_serviceProvider.GetService(providerType);
        }
    }
}
