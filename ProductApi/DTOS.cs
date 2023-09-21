using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace ProductApi
{
    public class DTOS
    {
        public record ProductDTO(Guid Id, string ProductName,int ProductPrice, DateTimeOffset CreatedTime,DateTimeOffset ModifiedTime);

        public record CreateProductDTO([Required] string ProductName,[Range(0,10000)]int ProductPrice);
        public record UpdateProductDTO([Required]string ProductName,[Range(0, 10000)]int ProductPrice);
    }
}
