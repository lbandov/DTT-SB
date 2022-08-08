using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Helpers
{
    public static class SimpleValidator
    {
        public static bool ValidateVatRegistrationRequest(VatRegistrationRequest request, out string message)
        {
            if (request == null)
            {
                message = "Request is null";
                return false;
            }
            if(string.IsNullOrEmpty(request.CompanyName))
            {
                message = "Request is missing companyName";
                return false;
            }
            if(string.IsNullOrEmpty(request.CompanyId))
            {
                message = "Request is missing companyId.";
                return false;
            }
            if(string.IsNullOrEmpty(request.Country))
            {
                message = "Request is missing country.";
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
