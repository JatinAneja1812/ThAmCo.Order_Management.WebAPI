namespace ThAmCo.Order_Management.WebAPI.Fakes.Products
{
    public interface IProductsFake
    {
        public List<ProductsDTO> GetAllAvailableProducts();
        public List<ProductsDTO> GetAllCategoryProducts(string categoryName);
    }
}
