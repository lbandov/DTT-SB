using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Services;
using Taxually.TechnicalTest.Services.VatProviders;

namespace Taxually.TechnicalTest.Tests.Unit
{
    public class VatRegistrationProviderFactoryTests
    {
        private IVatRegistrationProviderFactory _vatRegistrationProviderFactory;

        [SetUp]
        public void Setup()
        {
            var app = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RegisterServices();
                });
            });

            var provider = app.Services;

            _vatRegistrationProviderFactory = new VatRegistrationProviderFactory(provider);
        }

        [TestCase("GB", typeof(UKVatRegistrationProvider))]
        [TestCase("FR", typeof(FranceVatRegistrationProvider))]
        [TestCase("DE", typeof(GermanyVatRegistrationProvider))]
        public void ReturnCorrectProcessor(string countryCode, Type expectedType)
        {
            var processor = _vatRegistrationProviderFactory.GetProvider(countryCode);

            expectedType.Should().Be(processor.GetType());
        }

        [TestCase("JP")]
        [TestCase("BG")]
        public void ThrowsExceptionInCaseOfInvalidValue(string countryCode)
        {
            var exception = Assert.Throws<BadHttpRequestException>(() => _vatRegistrationProviderFactory.GetProvider(countryCode));

            exception.Should().BeOfType<BadHttpRequestException>("Country not supported");
        }
    }
}
