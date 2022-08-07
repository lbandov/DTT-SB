using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Services.VatProviders
{
    public class UKVatRegistrationProvider : IVatRegistrationProvider
    {
        private readonly ITaxuallyHttpClient _taxuallyHttpClient;
        public UKVatRegistrationProvider(ITaxuallyHttpClient taxuallyHttpClient)
        {
            _taxuallyHttpClient = taxuallyHttpClient;
        }
        public Task RegisterRequest(VatRegistrationRequest request)
        {
            return _taxuallyHttpClient.PostAsync("https://api.uktax.gov.uk", request);
        }
    }
}
