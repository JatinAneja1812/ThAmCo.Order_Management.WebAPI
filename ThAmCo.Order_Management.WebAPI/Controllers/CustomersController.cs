using DomainDTOs.Order;
using FakeData.Customers.ModelDTOs;
using FakeData.Customers.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Interfaces;

namespace ThAmCo.Order_Management.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerReviews _reviews;

        public CustomersController(ICustomerReviews Reviews)
        {
            _reviews = Reviews;
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
            catch (Exception)
            {
                return StatusCode(500, "Server error. Failed to retrive reviews from database.");
            }
        }
    }
}
