using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_6.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ApiContactController : ControllerBase
    {
        private readonly IProductService _productService;

        public ApiContactController(IProductService productService)
        {
            _productService = productService;
        }
        public List<string> GetAll()
        {
            return new List<string>()
            {
                "Adam", "Ewa", "Kacperek"
            };
        }
    }
}
