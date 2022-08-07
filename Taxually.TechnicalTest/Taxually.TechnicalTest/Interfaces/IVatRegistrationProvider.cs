using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Interfaces
{
    public interface IVatRegistrationProvider
    {
        Task RegisterRequest(VatRegistrationRequest request);
    }
}
