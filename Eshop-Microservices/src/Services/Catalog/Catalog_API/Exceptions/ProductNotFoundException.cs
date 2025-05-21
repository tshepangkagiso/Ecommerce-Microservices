namespace Catalog_API.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product Not Found.")
        {
        }

        public ProductNotFoundException(Guid Id) : base("Product Not Found.")
        {
        }
    }
}
