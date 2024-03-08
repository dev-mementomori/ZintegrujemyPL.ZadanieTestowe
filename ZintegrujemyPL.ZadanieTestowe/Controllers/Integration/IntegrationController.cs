using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Integrations;

namespace ZintegrujemyPL.ZadanieTestowe.Controllers.Data
{
    public class IntrgrationController : Controller
    {
        private readonly IIntegrationService _integrationService;
        public IntrgrationController(IIntegrationService integrationService)
        {
            _integrationService = integrationService;
        }

        [HttpGet("Integrate")]
        public async Task<IActionResult> Integrate()
        {
            await _integrationService.Integrate();
            return Ok();
        }
    }
}
