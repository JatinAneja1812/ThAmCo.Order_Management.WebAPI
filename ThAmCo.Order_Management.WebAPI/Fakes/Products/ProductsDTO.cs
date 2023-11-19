namespace ThAmCo.Order_Management.WebAPI.Fakes.Products
{
    public class ProductsDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Img { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double Reviews { get; set; }
        public int ReviewCount { get; set; }
        public string BrandName { get; set; }
        public bool Availability { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public string NutritionalInformation { get; set; }
        public List<UserCommentDTO> UserComments { get; set; }
    }

}
