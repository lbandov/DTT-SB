namespace Taxually.TechnicalTest.Interfaces
{
    public interface IVatRegistrationProviderFactory
    {
        IVatRegistrationProvider GetProvider(string countryCode);
    }
}
