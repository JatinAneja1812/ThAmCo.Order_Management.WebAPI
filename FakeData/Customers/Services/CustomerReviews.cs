using FakeData.Customers.ModelDTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FakeData.Customers.Services
{
    public class CustomerReviews : ICustomerReviews
    {
        private readonly HttpClient httpClient;
        private static readonly Random RandomGenerator = new Random();
        private readonly ILogger<CustomerReviews> _logger;
        public CustomerReviews(ILogger<CustomerReviews> Logger)
        {
            // Initialize HttpClient
            httpClient = new HttpClient();
            Logger = _logger;
        }

        private int GetRandomRating()
        {
            return RandomGenerator.Next(3, 5 + 1);
        }

        private string GetRandomReview()
        {
            var reviews = new List<string>
            {
                "Outstanding service! The delivery was quick, and the products exceeded my expectations.",
                "I've had a wonderful experience shopping here. The staff is friendly, and the selection is fantastic.",
                "Top-tier quality! Every purchase has been a delight, and I appreciate the attention to detail.",
                "Exceptional customer support. They go above and beyond to ensure customer satisfaction.",
                "Impressive variety and reasonable prices. This is my go-to place for all my shopping needs.",
                "Reliable and efficient. I've never been disappointed with my purchases.",
                "Five-star experience! The website is user-friendly, and the checkout process is seamless.",
                "Highly recommended. I've recommended this service to friends, and they love it too!",
                "Prompt delivery and great communication. I appreciate the effort they put into every order."
            };

            int randomIndex = RandomGenerator.Next(0, reviews.Count - 1);
            return reviews[randomIndex];
        }

        public async Task<List<UsersReviewDto>> GetUsersReviewAsync(int numberOfUsers = 9)
        {
            try
            {
                // Make the API request
                string apiUrl = $"https://randomuser.me/api/?results={numberOfUsers}";
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Check if the request was successful
                response.EnsureSuccessStatusCode();

                // Read and deserialize the JSON response into the DTO
                string jsonContent = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(jsonContent);

                // Extract and return the DTO array
                return ParseResults(result.results);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors as needed
                _logger.LogError($"External fake reviews API request failed: \n Error{ex.Message}. \n Stack trace: {ex.StackTrace}.");
                throw;
            }
        }

        private List<UsersReviewDto> ParseResults(dynamic results)
        {
            if(results == null)
            {
                return null;
            }

            var userDtos = new List<UsersReviewDto>();

            foreach (var result in results)
            {
                var userDto = new UsersReviewDto
                {
                    UserId = Guid.NewGuid().ToString(),
                    Title = result.name.title,
                    Firstname = result.name.first,
                    Lastname = result.name.last,
                    AvatarURL = result.picture.thumbnail,
                    Review = GetRandomReview().ToString(),
                    Rating = GetRandomRating()
                };

                userDtos.Add(userDto);
            }

            return userDtos;
        }
    }
}
