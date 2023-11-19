using Enums;
using ThAmCo.Order_Management.WebAPI.Fakes.Products;

namespace ThAmCo.Order_Management.WebAPI.Fakes.Products
{
    public class ProductsFake : IProductsFake
    {
        public readonly ILogger<ProductsFake> _logger;
        private readonly List<ProductsAndCategoriesDTO> _allProductsAndCategories;
        public ProductsFake(ILogger<ProductsFake> Logger) 
        { 
            _logger = Logger;
            _allProductsAndCategories = new List<ProductsAndCategoriesDTO>
            {
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Meat",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 0,
                            ProductName = "Beef Meat",
                            Img = "https://cdn.britannica.com/68/143268-050-917048EA/Beef-loin.jpg",
                            Price = 10.99,
                            Total = 10.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.5,
                            ReviewCount = 25,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "High-quality beef loin for your favorite recipes.",
                            Discount = 0.0,
                            NutritionalInformation = "Protein: 20g, Fat: 15g, Carbohydrates: 0g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 1, UserName = "John Doe", Comment = "Excellent quality!", Rating = 5 },
                                new UserCommentDTO { UserId = 2, UserName = "Jane Smith", Comment = "Very tasty!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 1,
                            ProductName = "Chicken Thighs",
                            Img = "https://meatmachine.co.uk/cdn/shop/products/ChickenBreastsMarch2018.jpg?v=1585680587",
                            Price = 7.99,
                            Total = 7.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.2,
                            ReviewCount = 18,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Tender and juicy chicken thighs, perfect for grilling.",
                            Discount = 0.0,
                            NutritionalInformation = "Protein: 15g, Fat: 10g, Carbohydrates: 2g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 3, UserName = "Mary Johnson", Comment = "Delicious!", Rating = 4 },
                                new UserCommentDTO { UserId = 4, UserName = "Bob Miller", Comment = "Great value!", Rating = 5 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 2,
                            ProductName = "Pork Ribs",
                            Img = "https://img.freepik.com/premium-photo/raw-pork-ribs-with-rosemary-isolated-white-raw-pork-ribs-served-rosemary-cooking-raw-meat-whole-raw-pork-ribs-raw-pork-meat-spare-ribs-belly_256259-2850.jpg",
                            Price = 12.99,
                            Total = 12.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.8,
                            ReviewCount = 32,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Delicious pork ribs, perfect for barbecue lovers.",
                            Discount = 0.0,
                            NutritionalInformation = "Protein: 18g, Fat: 15g, Carbohydrates: 1g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 5, UserName = "Eva Williams", Comment = "Amazing taste!", Rating = 5 },
                                new UserCommentDTO { UserId = 6, UserName = "Charlie Brown", Comment = "Great for parties!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 3,
                            ProductName = "Lamb Chops",
                            Img = "https://st.depositphotos.com/1027198/3583/i/950/depositphotos_35836067-stock-photo-raw-lamb-chop.jpg",
                            Price = 15.99,
                            Total = 15.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.7,
                            ReviewCount = 28,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Premium lamb chops for an exquisite dining experience.",
                            Discount = 0.0,
                            NutritionalInformation = "Protein: 22g, Fat: 18g, Carbohydrates: 0g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 7, UserName = "Ale xGreen", Comment = "Melt-in-your-mouth goodness!", Rating = 5 },
                                new UserCommentDTO { UserId = 8, UserName = "Olivia Smith", Comment = "Perfectly cooked!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 4,
                            ProductName = "Turkey",
                            Img = "https://media.istockphoto.com/id/1282866808/photo/fresh-raw-chicken.jpg?s=612x612&w=0&k=20&c=QtfdAhdeIGpR3JUNDmYFo6cN0el8oYMcOXMQI7Qder4=",
                            Price = 9.99,
                            Total = 9.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.4,
                            ReviewCount = 20,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Premium turkey meat for a festive feast.",
                            Discount = 0.0,
                            NutritionalInformation = "Protein: 16g, Fat: 10g, Carbohydrates: 2g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 9, UserName = "Sophia Brown", Comment = "Great flavor!", Rating = 4 },
                                new UserCommentDTO { UserId = 10, UserName = "James Miller", Comment = "Perfect for Thanksgiving!", Rating = 5 }
                            }
                        }
                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Vegetables",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 5,
                            ProductName = "Tomato",
                            Img = "https://cdnprod.mafretailproxy.com/sys-master-root/hcf/h7c/9913197854750/71610_main.jpg_480Wx480H",
                            Price = 2.99,
                            Total = 2.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.6,
                            ReviewCount = 22,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Plump and juicy tomatoes, perfect for salads and cooking.",
                            Discount = 0.0,
                            NutritionalInformation = "Vitamin C: 20mg, Fiber: 2g, Calories: 18",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 1, UserName = "Amy White", Comment = "Fresh and delicious!", Rating = 5 },
                                new UserCommentDTO { UserId = 2, UserName = "Chris Black", Comment = "Great quality!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 6,
                            ProductName = "Carrot",
                            Img = "https://shop.wattsfarms.co.uk/cdn/shop/products/CarrotsBunch_656x.png?v=1584661335",
                            Price = 1.99,
                            Total = 1.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.3,
                            ReviewCount = 17,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Sweet and crunchy carrots, perfect for snacks and meals.",
                            Discount = 0.0,
                            NutritionalInformation = "Vitamin A: 5000 IU, Fiber: 3g, Calories: 30",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 3, UserName = "David Brown", Comment = "Excellent flavor!", Rating = 4 },
                                new UserCommentDTO { UserId = 4, UserName = "Emma Green", Comment = "Love the freshness!", Rating = 5 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 7,
                            ProductName = "Spinach",
                            Img = "https://shop.wattsfarms.co.uk/cdn/shop/products/spinachlarge_383x.png?v=1591729495",
                            Price = 3.99,
                            Total = 3.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.7,
                            ReviewCount = 28,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Nutrient-rich spinach, perfect for salads and smoothies.",
                            Discount = 0.0,
                            NutritionalInformation = "Iron: 5mg, Vitamin K: 150mcg, Calories: 23",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 5, UserName = "Grace Smith", Comment = "Healthy and fresh!", Rating = 5 },
                                new UserCommentDTO { UserId = 6, UserName = "John Davis", Comment = "Great for green smoothies!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 8,
                            ProductName = "Broccoli",
                            Img = "https://domf5oio6qrcr.cloudfront.net/medialibrary/5390/h1218g16207258089583.jpg",
                            Price = 2.49,
                            Total = 2.49,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.4,
                            ReviewCount = 20,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Fresh and nutritious broccoli, perfect for stir-fries and side dishes.",
                            Discount = 0.0,
                            NutritionalInformation = "Fiber: 2.4g, Vitamin C: 43mg, Calories: 31",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 7, UserName = "Olivia Johnson", Comment = "Love the freshness!", Rating = 5 },
                                new UserCommentDTO { UserId = 8, UserName = "William White", Comment = "Great addition to meals!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 9,
                            ProductName = "Bell Pepper",
                            Img = "https://cdn.britannica.com/12/147312-050-BEC6A59E/Bell-peppers.jpg",
                            Price = 1.79,
                            Total = 1.79,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.8,
                            ReviewCount = 32,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Colorful bell peppers, perfect for salads and cooking.",
                            Discount = 0.0,
                            NutritionalInformation = "Vitamin A: 3726 IU, Vitamin C: 127.7mg, Calories: 31",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 9, UserName = "Sophia Miller", Comment = "Fresh and crispy!", Rating = 5 },
                                new UserCommentDTO { UserId = 10, UserName = "James Wilson", Comment = "Excellent quality!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 10,
                            ProductName = "Cucumber",
                            Img = "https://cdnprod.mafretailproxy.com/sys-master-root/h64/h35/35140082368542/1700Wx1700H_32594_main.jpg",
                            Price = 1.29,
                            Total = 1.29,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.2,
                            ReviewCount = 15,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Cool and refreshing cucumbers, perfect for salads and snacks.",
                            Discount = 0.0,
                            NutritionalInformation = "Vitamin K: 16.4mcg, Calories: 15",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 11, UserName = "Ava Davis", Comment = "Always fresh!", Rating = 5 },
                                new UserCommentDTO { UserId = 12, UserName = "Daniel Taylor", Comment = "Great for salads!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 11,
                            ProductName = "Aubergine",
                            Img = "https://mapetiteassiette.com/wp-content/uploads/2020/07/aubergine.jpg",
                            Price = 1.99,
                            Total = 1.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.5,
                            ReviewCount = 18,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Versatile aubergines, great for grilling and roasting.",
                            Discount = 0.0,
                            NutritionalInformation = "Fiber: 3g, Calories: 20",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 13, UserName = "Ella Clark", Comment = "Love the quality!", Rating = 5 },
                                new UserCommentDTO { UserId = 14, UserName = "Jack Moore", Comment = "Perfect for recipes!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 12,
                            ProductName = "Raddish",
                            Img = "https://www.lakshmistores.com/cdn/shop/products/RADDISH-_MULLANGI_b4616dfe-fecf-491f-a6bb-55732c41db96.jpg?v=1639172431",
                            Price = 1.49,
                            Total = 1.49,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.3,
                            ReviewCount = 16,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Crunchy and vibrant raddishes, perfect for salads and garnishes.",
                            Discount = 0.0,
                            NutritionalInformation = "Vitamin C: 15mg, Fiber: 2g, Calories: 16",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 15, UserName = "Mia Moore", Comment = "Fresh and crisp!", Rating = 5 },
                                new UserCommentDTO { UserId = 16, UserName = "Noah King", Comment = "Great addition to salads!", Rating = 4 }
                            }
                        },
                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Fruits",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 13,
                            ProductName = "Apple",
                            Img = "https://domf5oio6qrcr.cloudfront.net/medialibrary/11525/0a5ae820-7051-4495-bcca-61bf02897472.jpg",
                            Price = 1.49,
                            Total = 1.49,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.2,
                            ReviewCount = 16,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Sweet and crisp apples, perfect for snacks and desserts.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 52, Carbohydrates: 14g, Fiber: 2.4g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 27, UserName = "HarperTaylor", Comment = "Delicious apples!", Rating = 5 },
                                new UserCommentDTO { UserId = 28, UserName = "ElijahMiller", Comment = "Always fresh and crunchy.", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 14,
                            ProductName = "Grapes",
                            Img = "https://www.heddensofwoodtown.co.uk/wp-content/uploads/2020/05/grapes_green_opt.jpg",
                            Price = 3.99,
                            Total = 3.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.5,
                            ReviewCount = 24,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Sweet and juicy green grapes, perfect for snacking.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 288, Sugars: 69g, Vitamin C: 3.7mg",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 17, UserName = "LiamBaker", Comment = "Absolutely delicious!", Rating = 5 },
                                new UserCommentDTO { UserId = 18, UserName = "EmmaMoore", Comment = "Great quality grapes!", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 15,
                            ProductName = "Banana",
                            Img = "https://static.libertyprim.com/files/familles/banane-large.jpg?1569271725",
                            Price = 0.99,
                            Total = 0.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.0,
                            ReviewCount = 12,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Naturally sweet and nutritious bananas, perfect for breakfast or snacks.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 105, Carbohydrates: 27g, Potassium: 422mg",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 19, UserName = "EthanCarter", Comment = "Always fresh bananas!", Rating = 4 },
                                new UserCommentDTO { UserId = 20, UserName = "AvaClark", Comment = "Great value for money.", Rating = 3 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 16,
                            ProductName = "Orange",
                            Img = "https://5.imimg.com/data5/SELLER/Default/2023/5/305062155/SB/TM/XR/86539219/fresh-orange-fruit-500x500.jpg",
                            Price = 1.79,
                            Total = 1.79,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.3,
                            ReviewCount = 18,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Sweet and tangy oranges, packed with Vitamin C.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 52, Vitamin C: 96mg, Fiber: 2.4g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 21, UserName = "OliviaDavis", Comment = "Love the juicy flavor!", Rating = 5 },
                                new UserCommentDTO { UserId = 22, UserName = "NoahWilson", Comment = "Great for making fresh juice.", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 17,
                            ProductName = "Pineapple",
                            Img = "https://3.imimg.com/data3/VK/HO/MY-3449298/fresh-pineapple-500x500.jpg",
                            Price = 2.99,
                            Total = 2.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.7,
                            ReviewCount = 28,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Delicious and tropical pineapples, perfect for desserts and snacks.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 50, Vitamin C: 47.8mg, Fiber: 2.3g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 23, UserName = "SophiaSmith", Comment = "Amazingly sweet!", Rating = 5 },
                                new UserCommentDTO { UserId = 24, UserName = "DanielBrown", Comment = "Great quality pineapples.", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 18,
                            ProductName = "Mango",
                            Img = "https://www.svz.com/wp-content/uploads/2018/05/Mango.jpg",
                            Price = 2.49,
                            Total = 2.49,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.6,
                            ReviewCount = 22,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Sweet and succulent mangoes, perfect for snacking or smoothies.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 60, Vitamin C: 36.4mg, Fiber: 1.6g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 25, UserName = "MiaJones", Comment = "Love the freshness!", Rating = 5 },
                                new UserCommentDTO { UserId = 26, UserName = "WilliamWhite", Comment = "Best mangoes in town.", Rating = 4 }
                            }
                        },
                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Dairy",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 19,
                            ProductName = "Milk",
                            Img = "https://drinkmilk.co.uk/wp-content/uploads/2021/02/Office-Milk-Bottles-Shelf.png",
                            Price = 1.99,
                            Total = 1.99,
                            Quantity = 1,
                            Unit = "ltr",
                            Reviews = 4.4,
                            ReviewCount = 19,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Fresh and nutritious milk, perfect for daily consumption.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 42, Protein: 3.4g, Calcium: 276mg",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 29, UserName = "OliviaSmith", Comment = "Great for coffee!", Rating = 4 },
                                new UserCommentDTO { UserId = 30, UserName = "DanielJohnson", Comment = "High-quality milk.", Rating = 5 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 20,
                            ProductName = "Cheese x12",
                            Img = "https://urbanmerchants.co.uk/wp-content/uploads/2022/11/emmental-cheese-main-500px.jpg",
                            Price = 4.99,
                            Total = 4.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.8,
                            ReviewCount = 32,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Delicious cheese slices, perfect for sandwiches and snacks.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 356, Fat: 29g, Protein: 21g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 31, UserName = "SophiaDavis", Comment = "Tasty and creamy.", Rating = 4 },
                                new UserCommentDTO { UserId = 32, UserName = "WilliamTaylor", Comment = "Great for burgers!", Rating = 5 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 21,
                            ProductName = "Eggs",
                            Img = "https://kellysthoughtsonthings.com/wp-content/uploads/2020/03/large_1e1b7679-fb61-4b81-9d34-009e3276cfeb-27272.jpg.webp",
                            Price = 1.99,
                            Total = 1.99,
                            Quantity = 1,
                            Unit = "dozen",
                            Reviews = 4.2,
                            ReviewCount = 15,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Farm-fresh eggs, rich in protein and nutrients.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 68, Protein: 6g, Fat: 4.8g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 33, UserName = "EllaBrown", Comment = "Great quality eggs!", Rating = 5 },
                                new UserCommentDTO { UserId = 34, UserName = "HenryClark", Comment = "Perfect for baking.", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 22,
                            ProductName = "Butter",
                            Img = "https://www.bhg.com/thmb/-luCrhu9Eh1C2u-oZXseX5tKAbk=/3000x0/filters:no_upscale():strip_icc()/bhg-how-many-grams-are-in-one-stick-of-butter-03-2c71be43bb20474384f7483c3827f8e7.jpg",
                            Price = 3.49,
                            Total = 3.49,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.6,
                            ReviewCount = 22,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Creamy and flavorful butter, ideal for cooking and spreading.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 717, Fat: 81g, Vitamin A: 900mcg",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 35, UserName = "MiaWilson", Comment = "Love the taste!", Rating = 5 },
                                new UserCommentDTO { UserId = 36, UserName = "LiamAnderson", Comment = "Excellent for baking.", Rating = 4 }
                            }
                        },
                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Grains",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 23,
                            ProductName = "Quinoa",
                            Img = "https://images.immediate.co.uk/production/volatile/sites/30/2020/02/Quinoa-d02ed5b.jpg?resize=960%2C503",
                            Price = 5.99,
                            Total = 5.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.5,
                            ReviewCount = 21,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Nutrient-rich quinoa, a versatile and healthy grain alternative.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 120, Protein: 4g, Fiber: 2.8g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 37, UserName = "NoahMiller", Comment = "Great addition to salads.", Rating = 5 },
                                new UserCommentDTO { UserId = 38, UserName = "EmmaBrown", Comment = "High-quality quinoa.", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 24,
                            ProductName = "Brown Rice",
                            Img = "https://www.planetorganic.com/cdn/shop/products/24071.jpg?v=1667837297",
                            Price = 4.49,
                            Total = 4.49,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.3,
                            ReviewCount = 17,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Whole grain brown rice, a nutritious and hearty staple.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 215, Carbs: 45g, Fiber: 3.5g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 39, UserName = "AidenJohnson", Comment = "Excellent rice quality.", Rating = 5 },
                                new UserCommentDTO { UserId = 40, UserName = "AvaDavis", Comment = "Perfect for stir-fries.", Rating = 4 }
                            }
                        },
                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Beverages",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 25,
                            ProductName = "Green Tea x20",
                            Img = "https://everyday.booths.co.uk/media/catalog/product/cache/78b315bc9c0c3244ff3e015e46ad2616/1/7/172081_front.jpg",
                            Price = 3.49,
                            Total = 3.49,
                            Quantity = 1,
                            Unit = "box",
                            Reviews = 4.6,
                            ReviewCount = 22,
                            BrandName = "Tetley",
                            Availability = true,
                            Description = "High-quality green tea with antioxidants for a refreshing experience.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 0, Antioxidants: High, Caffeine: Low",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 43, UserName = "Mia Wilson", Comment = "Love the taste!", Rating = 5 },
                                new UserCommentDTO { UserId = 44, UserName = "Lucas Anderson", Comment = "Great for relaxation.", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 26,
                            ProductName = "Orange Juice",
                            Img = "https://assets.sainsburys-groceries.co.uk/gol/2537443/1/640x640.jpg",
                            Price = 2.99,
                            Total = 2.99,
                            Quantity = 1,
                            Unit = "ltr",
                            Reviews = 4.3,
                            ReviewCount = 17,
                            BrandName = "Tropicana",
                            Availability = true,
                            Description = "Freshly squeezed orange juice, rich in vitamin C for a healthy boost.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 110, Vitamin C: 50mg, Sugar: 22g",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 45, UserName = "Jackson Harris", Comment = "Delicious and refreshing.", Rating = 5 },
                                new UserCommentDTO { UserId = 46, UserName = "Avery Clark", Comment = "Great quality juice.", Rating = 4 }
                            }
                        },

                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Pet Foods",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 27,
                            ProductName = "Premium Cat Food",
                            Img = "https://redmillsstore.co.uk/cdn/shop/products/WinnerCatAdultChicken.jpg?v=1623160848g",
                            Price = 5.99,
                            Total = 5.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.8,
                            ReviewCount = 28,
                            BrandName = "Winner",
                            Availability = true,
                            Description = "High-quality cat food with a balanced mix of nutrients for your feline friend.",
                            Discount = 0.0,
                            NutritionalInformation = "Protein: 30%, Fat: 15%, Fiber: 5%",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 55, UserName = "Sophie Miller", Comment = "My cat loves it!", Rating = 5 },
                                new UserCommentDTO { UserId = 56, UserName = "Ethan Scott", Comment = "Great for picky eaters.", Rating = 4 }
                            }
                        },
                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Snacks",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 28,
                            ProductName = "Potato Chips",
                            Img = "https://i.ebayimg.com/images/g/q38AAOSwLTpjxtsq/s-l1200.webp",
                            Price = 1.69,
                            Total = 1.69,
                            Quantity = 1,
                            Unit = "grams",
                            Reviews = 4.2,
                            ReviewCount = 15,
                            BrandName = "Lays",
                            Availability = true,
                            Description = "Crunchy and flavorful flamin hot potato chips for your snack time.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 150 per serving",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 57, UserName = "Emma Johnson", Comment = "Delicious!", Rating = 4 },
                                new UserCommentDTO { UserId = 58, UserName = "Noah Williams", Comment = "My favorite snack.", Rating = 5 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 29,
                            ProductName = "Chocolate Bars Assortment",
                            Img = "https://assets.sainsburys-groceries.co.uk/gol/7793267/1/640x640.jpg",
                            Price = 2.99,
                            Total = 2.99,
                            Quantity = 1,
                            Unit = "pack",
                            Reviews = 4.5,
                            ReviewCount = 24,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "A delightful assortment of chocolate bars for a sweet treat.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: Varies by flavor",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 59, UserName = "Olivia Smith", Comment = "Yummy chocolates!", Rating = 5 },
                                new UserCommentDTO { UserId = 60, UserName = "Liam Brown", Comment = "Great variety.", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 30,
                            ProductName = "Trail Mix",
                            Img = "https://m.media-amazon.com/images/I/61z4jHVthPL._AC_UF1000,1000_QL80_.jpg",
                            Price = 1.29,
                            Total = 1.29,
                            Quantity = 1,
                            Unit = "pack",
                            Reviews = 4.7,
                            ReviewCount = 28,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "A healthy and tasty smokin BBQ trail mix with a mix of nuts and dried fruits.",
                            Discount = 0.0,
                            NutritionalInformation = "Protein: 8g, Fiber: 5g per serving",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 61, UserName = "Ava Johnson", Comment = "Perfect for hiking.", Rating = 5 }
                            }
                        },
                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Chocolates",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 31,
                            ProductName = "Dark Chocolate Bar",
                            Img = "https://www.choc-affair.com/wp-content/uploads/2022/02/coffee-dark-chocolate-bar-90g.jpg",
                            Price = 2.99,
                            Total = 2.99,
                            Quantity = 1,
                            Unit = "grams",
                            Reviews = 4.4,
                            ReviewCount = 20,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Indulge in the rich and smooth flavor of dark chocolate.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 100 per serving",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 63, UserName = "Isabella Clark", Comment = "Perfect for chocolate lovers.", Rating = 5 },
                                new UserCommentDTO { UserId = 64, UserName = "Jackson Lee", Comment = "Great quality dark chocolate.", Rating = 4 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 32,
                            ProductName = "Milk Chocolate Truffles",
                            Img = "https://trwffl.co.uk/cdn/shop/products/sea_salt_chocolate_pack8-scaled.png?v=1686259419&width=1946",
                            Price = 2.99,
                            Total = 2.99,
                            Quantity = 1,
                            Unit = "box",
                            Reviews = 4.8,
                            ReviewCount = 32,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Savor the creamy goodness of milk chocolate truffles.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: Varies by truffle",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 65, UserName = "Sophia White", Comment = "Absolutely delicious!", Rating = 5 },
                                new UserCommentDTO { UserId = 66, UserName = "Jack Smith", Comment = "Irresistible truffles.", Rating = 5 }
                            }
                        },
                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Ice-creams",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 33,
                            ProductName = "Vanilla Bean Ice Cream",
                            Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTGVOMd8RWA5zntryoiCuh4sT6aeABAerVhZysvpxktS1nnnXer17M3TSB9VR_ZogRoXu4&usqp=CAU",
                            Price = 3.49,
                            Total = 3.49,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.6,
                            ReviewCount = 22,
                            BrandName = "Real Fresh",
                            Availability = true,
                            Description = "Classic vanilla ice cream made with real vanilla beans.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 200 per serving",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 67, UserName = "Emma Brown", Comment = "Smooth and creamy.", Rating = 4 },
                                new UserCommentDTO { UserId = 68, UserName = "William Davis", Comment = "Perfect for desserts.", Rating = 5 }
                            }
                        },
                        new ProductsDTO
                        {
                            ProductId = 34,
                            ProductName = "Chocolate Cookie and Cream",
                            Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSPiDII7vck0ShF1CzYXkf3UORzr97vGwQUJ_osy6Fa3YLrMKliWljHVIWrqPKexXr7dOM&usqp=CAU",
                            Price = 2.99,
                            Total = 2.99,
                            Quantity = 1,
                            Unit = "kg",
                            Reviews = 4.7,
                            ReviewCount = 28,
                            BrandName = "ThAmCo Fresh",
                            Availability = true,
                            Description = "Indulge in the rich flavor of crunchy chocolate cookies ice cream.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 220 per serving",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 69, UserName = "Olivia Wilson", Comment = "A chocolate lover's delight.", Rating = 5 },
                                new UserCommentDTO { UserId = 70, UserName = "Daniel Miller", Comment = "Irresistible crunch of cookiew.", Rating = 4 }
                            }
                        },
                    }
                },
                new ProductsAndCategoriesDTO
                {
                    CategoryName = "Breakfast Foods",
                    Items = new List<ProductsDTO>
                    {
                        new ProductsDTO
                        {
                            ProductId = 35,
                            ProductName = "Whole Grain Oatmeal",
                            Img = "https://www.koelln.com/fileadmin/user_upload/En/Product_packshots/Koelln_packshot_Wholegrain_Oats_375g_rgb_72.png",
                            Price = 3.99,
                            Total = 3.99,
                            Quantity = 1,
                            Unit = "pack",
                            Reviews = 4.4,
                            ReviewCount = 20,
                            BrandName = "Kollns",
                            Availability = true,
                            Description = "Nutritious whole grain oatmeal for a wholesome breakfast.",
                            Discount = 0.0,
                            NutritionalInformation = "Calories: 150 per serving",
                            UserComments = new List<UserCommentDTO>
                            {
                                new UserCommentDTO { UserId = 71, UserName = "Taylor James", Comment = "Healthy and delicious.", Rating = 4 },
                                new UserCommentDTO { UserId = 72, UserName = "Ethan Anderson", Comment = "Great way to start the day.", Rating = 5 }
                            }
                        },
                    }
                },
            };
        }

        public List<ProductsDTO> GetAllAvailableProducts()
        {
            try
            {
                // Flatten the list to get all products
                var allProducts = _allProductsAndCategories
                    .SelectMany(category => category.Items)
                    .ToList();

                return allProducts;
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(
                    new EventId((int)LogEventIdEnum.UnknownError),
                    $"An error occurred while getting all available products.\nException: {ex.Message}\nInner exception: {ex.InnerException}\nStack trace: {ex.StackTrace}");

                // Return an empty list in case of an error
                return new List<ProductsDTO>();
            }
        }

        public List<ProductsDTO> GetAllCategoryProducts(string categoryName)
        {
            try
            {
                // Find the specified category
                var selectedCategory = _allProductsAndCategories
                    .FirstOrDefault(category => category.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

                // Return products of the specified category if found
                return selectedCategory?.Items ?? new List<ProductsDTO>();
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(
                    new EventId((int)LogEventIdEnum.UnknownError),
                    $"An error occurred while getting products for category '{categoryName}'.\nException: {ex.Message}\nInner exception: {ex.InnerException}\nStack trace: {ex.StackTrace}");

                // Return an empty list in case of an error
                return new List<ProductsDTO>();
            }
        }
    }
}
