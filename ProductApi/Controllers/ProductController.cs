using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ProductApi.DTOS;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<ProductDTO> products = new()
        {
            new ProductDTO(Guid.NewGuid(),"Termék1",2500,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow),
            new ProductDTO(Guid.NewGuid(),"Termék2",2400,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow),
            new ProductDTO(Guid.NewGuid(),"Termék3",2300,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow)
        };
    }
}
