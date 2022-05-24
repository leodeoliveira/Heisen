using Heisen.Core.Abstraction;
using Heisen.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceTableController : ControllerBase
    {
        private readonly IPriceTableService _tableService;
        public PriceTableController(IPriceTableService priceTableService)
        {
            _tableService = priceTableService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_tableService.Get());
        }
    }
}
