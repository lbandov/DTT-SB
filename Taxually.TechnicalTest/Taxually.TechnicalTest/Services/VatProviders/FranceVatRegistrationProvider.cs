using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Services.VatProviders
{
    public class FranceVatRegistrationProvider : IVatRegistrationProvider
    {
        private readonly ITaxuallyQueueClient _taxuallyQueueClient;
        private readonly ICsvService _csvService;
        public FranceVatRegistrationProvider(ITaxuallyQueueClient taxuallyQueueClient, ICsvService csvService)
        {
            _taxuallyQueueClient = taxuallyQueueClient;
            _csvService = csvService;
        }
        public Task RegisterRequest(VatRegistrationRequest request)
        {
            var csv = _csvService.ProcessToCsv(request);
            return _taxuallyQueueClient.EnqueueAsync("vat-registration-csv", csv);
        }
    }
}
