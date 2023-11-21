using Auth0.ManagementApi;
using DomainDTOs.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using System.Data;
using System.IdentityModel.Tokens.Jwt;

namespace ThAmCo.Order_Management.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService OrderService, ILogger<OrderController> Logger)
        {
            _orderService = OrderService;
            _logger = Logger;
        }

        // GET: api/Order/GetAllOrders
        [Authorize]
        [HttpGet]
        [Route("GetAllOrders")]
        public ActionResult<List<OrderDTO>> GetAllOrders([FromHeader] string Authorization) 
        {
            return BadRequest();
        }

        //static bool VerifyToken(string accessToken, string auth0Domain, string audience)
        //{
        //    var handler = new JwtSecurityTokenHandler();

        //    // Decode the token
        //    var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;

        //    // Get the issuer from the token's payload
        //    var issuer = jsonToken.Header.ContainsKey("iss")
        //        ? jsonToken.Header["iss"].ToString()
        //        : throw new InvalidOperationException("Issuer not found in token payload");

        //    // Use the default Auth0 JWKS URI
        //    var defaultJwksUri = $"{issuer}.well-known/jwks.json";

        //    // Fetch the Auth0 JWKS (JSON Web Key Set)
        //    var jwksResponse = new HttpClient().GetStringAsync(defaultJwksUri).Result;

        //    // Deserialize JWKS response
        //    var jsonWebKeySet = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonWebKeySet>(jwksResponse);

        //    // Validate the token using the JWKS
        //    var validationParameters = new TokenValidationParameters
        //    {
        //        ValidIssuer = auth0Domain,
        //        ValidAudience = audience,
        //        ValidateLifetime = true,
        //        ClockSkew = TimeSpan.FromMinutes(5), // Adjust as needed
        //    };

        //    try
        //    {
        //        SecurityToken validatedToken;
        //        var principal = handler.ValidateToken(accessToken, validationParameters, out validatedToken);

        //        // Access claims from the validated token if needed
        //        // var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}


        public class DiscoveryDocument
        {
            public string JwksUri { get; set; }
            // Add other properties if needed
        }


        // GET: api/Order/GetAllOrders? OrderIDsDTO - List<string> { [ Id1, Id2 ] }
        [HttpGet]
        [Route("GetOrdersById")]
        public ActionResult<List<OrderDTO>> GetOrdersById([FromBody] OrderIDsDTO orderIds)
        {
            return BadRequest();
        }

        // POST api/Order/AddOrder? AddNewOrderDTO
        [HttpPost]
        [Route("AddOrder")]
        public ActionResult<bool> AddNewOrder([FromBody] AddNewOrderDTO order)
        {
            return BadRequest();
        }

        // PUT api/Order/UpdateExistingOrder? OrderDTO
        [HttpPut]
        [Route("UpdateExistingOrder")]
        public ActionResult<bool> UpdateExistingOrder([FromBody] OrderDTO order)
        {
            return BadRequest();
        }

        // PUT api/Order/UpdateOrderDelivery? ScheduledOrderDTO
        [HttpPut]
        [Route("UpdateOrderDelivery")]
        public ActionResult<bool> UpdateExistingOrderWithDelivery([FromBody] ScheduledOrderDTO order)
        {
            return BadRequest();
        }

        // PUT api/Order/UpdateOrderStatus? OrderDTO
        [HttpPut]
        [Route("UpdateOrderStatus")]
        public ActionResult<bool> UpdateOrderStatus([FromBody] OrderStatusDTO order )
        {
            return BadRequest();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete]
        [Route("CancelOrder")]
        public ActionResult<bool> Delete([FromBody] OrderIDsDTO orderIds)
        {
            return BadRequest();
        }
    }
}
