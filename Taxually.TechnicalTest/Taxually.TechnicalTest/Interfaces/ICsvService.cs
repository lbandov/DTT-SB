using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Interfaces
{
    public interface ICsvService
    {
        byte[] ProcessToCsv(VatRegistrationRequest request);
    }
}
