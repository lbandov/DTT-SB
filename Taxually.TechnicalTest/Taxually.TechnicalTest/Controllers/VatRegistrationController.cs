using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Helpers;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IVatRegistrationProviderFactory _vatRegistrationProviderFactory;

        public VatRegistrationController(IVatRegistrationProviderFactory vatRegistrationProviderFactory)
        {
            _vatRegistrationProviderFactory = vatRegistrationProviderFactory;
        }
        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            //do request validation in a pipeline like MediatR or validation class that returns useful errors 
            if(!SimpleValidator.ValidateVatRegistrationRequest(request, out var message))
            {
                return BadRequest(message);
            }
            var provider = _vatRegistrationProviderFactory.GetProvider(request.Country);
            await provider.RegisterRequest(request);
            return Ok();
        }

      
    }
}
