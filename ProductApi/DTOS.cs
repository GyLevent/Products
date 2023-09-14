using System.Transactions;

namespace ProductApi
{
    public class DTOS
    {
        public record ProductDTO(Guid Id, string ProductName,int ProductPrice, DateTimeOffset CreatedTime,DateTimeOffset ModifiedTime);

        public record CreateProductDTO(string ProductName,int ProductPrice);
        public record UpdateProductDTO(string ProductName, int ProductPrice);
    }
}
