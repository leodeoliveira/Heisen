using Heisen.Core.Abstraction;
using Heisen.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService ServiceService)
        {
            _serviceService = ServiceService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_serviceService.Get());
        }

        [HttpPost]
        public JsonResult Add(Service service)
        {
            return new JsonResult(_serviceService.Add(service));
        }

        [HttpPut]
        public JsonResult Put(Service service)
        {
            return new JsonResult(_serviceService.Update(service));
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Service service = _serviceService.GetById(id);
            return new JsonResult(_serviceService.Update(service));
        }
    }
}
