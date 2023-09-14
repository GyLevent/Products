using System.Transactions;

namespace ProductApi
{
    public class DTOS
    {
        public record ProductDTO(Guid Id, string ProductName,int ProductPrice, DateTimeOffset CreatedTime,DateTimeOffset ModifiedTime);
    }
}
