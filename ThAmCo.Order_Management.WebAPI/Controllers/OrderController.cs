using DomainDTOs.Order;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

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
        [HttpGet]
        [Route("GetAllOrders")]
        public ActionResult<List<OrderDTO>> GetAllOrders()
        {
            return BadRequest();
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
