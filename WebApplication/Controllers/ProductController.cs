using Heisen.Core.Abstraction;
using Heisen.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_productService.Get());
        }

        [HttpPost]
        public JsonResult Add(Product Product)
        {
            return new JsonResult(_productService.Add(Product));
        }

        [HttpPut]
        public JsonResult Put(Product Product)
        {
            return new JsonResult(_productService.Update(Product));
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Product Product = _productService.GetById(id);
            return new JsonResult(_productService.Update(Product));
        }
    }
}
