using System.Xml.Serialization;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Services
{
    public class XmlService : IXmlService
    {
        public string ProcessToXml(VatRegistrationRequest request)
        {
            using var stringwriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
            serializer.Serialize(stringwriter, this);
            return stringwriter.ToString();
        }
    }
}
