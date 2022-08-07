using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Services.VatProviders
{
    public class GermanyVatRegistrationProvider : IVatRegistrationProvider
    {
        private readonly ITaxuallyQueueClient _taxuallyQueueClient;
        public GermanyVatRegistrationProvider(ITaxuallyQueueClient taxuallyQueueClient)
        {
            _taxuallyQueueClient = taxuallyQueueClient;
        }
        public Task RegisterRequest(VatRegistrationRequest request)
        {
            return _taxuallyQueueClient.EnqueueAsync("vat-registration-xml", request);
        }
    }
}
