using Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThAmCo.Order_Management.WebAPI.Fakes.UserReviews;

namespace ThAmCo.Order_Management.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerReviewsFake _reviews;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomerReviewsFake Reviews, ILogger<CustomersController> logger)
        {
            _reviews = Reviews;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllReviews")]
        public async Task<ActionResult<List<UsersReviewDto>>> GetAllReviews()
        {
            try
            {
                var result = await _reviews.GetUsersReviewAsync();

                if (result == null)
                {
                    return StatusCode(500, "Failed to retrieve customer reviews from the database.");
                }

                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(
                 new EventId((int)LogEventIdEnum.UnknownError),
                 $"Unexpected exception was caught in CustomersController.\nException:\n{ex.Message}\nInner exception:\n{ex.InnerException}\nStack trace:\n{ex.StackTrace}");

                return StatusCode(500, "Server error. An unknown error occurred on the server..");
            }
        }
    }
}
