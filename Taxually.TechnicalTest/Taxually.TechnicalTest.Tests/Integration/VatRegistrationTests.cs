using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Tests.Integration
{
    public class VatRegistrationTests
    {
        private HttpClient client;
        private const string controllerPath = "api/VatRegistration";

        [SetUp]
        public void Setup()
        {
            var application = new WebApplicationFactory<Program>();

            client = application.CreateClient();
        }

        [TestCase("GB")]
        [TestCase("FR")]
        [TestCase("DE")]
        public async Task SendVatRegistrationRequest_ShouldResultInOkStatusCode(string countryCode)
        {
            var jsonContent = JsonContent.Create(new VatRegistrationRequest()
            {
                CompanyId = Guid.NewGuid().ToString(),
                CompanyName = "NewGuid",
                Country = countryCode,
            });

            var result = await client.PostAsync(controllerPath, jsonContent);

            Assert.IsTrue(result.IsSuccessStatusCode, $"Code was {result.StatusCode} ({(int)result.StatusCode})");

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [TestCase("")]
        [TestCase("BG")]
        [TestCase("55")]
        public async Task SendVatRegistrationRequest_ShouldResultInErrorCode(string countryCode)
        {
            var jsonContent = JsonContent.Create(new VatRegistrationRequest()
            {
                CompanyId = Guid.NewGuid().ToString(),
                CompanyName = "Microsoft",
                Country = countryCode,
            });

            var result = await client.PostAsync(controllerPath, jsonContent);

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}