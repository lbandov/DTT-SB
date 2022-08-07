using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Interfaces
{
    public interface IXmlService
    {
        string ProcessToXml(VatRegistrationRequest request);
    }
}
