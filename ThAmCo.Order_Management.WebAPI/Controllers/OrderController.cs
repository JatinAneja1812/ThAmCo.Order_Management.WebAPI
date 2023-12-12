using DomainDTOs.Order;
using DomainObjects.Orders;
using Enums;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

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
        //[Authorize]
        [HttpGet]
        [Route("GetAllOrders")]
        public ActionResult<List<OrderDTO>> GetAllOrders()
        {
            try
            {
                List<OrderDTO> result = _orderService.GetAllOrders();

                if (result == null)
                {
                    return StatusCode(500,
                        "Failed to retrieve all orders details from the database. If this error presists contact administrator");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                 new EventId((int)LogEventIdEnum.UnknownError),
                 $"Unexpected exception was caught in OrderController at GetAllOrders() .\nException:\n{ex.Message}\nInner exception:\n{ex.InnerException}\nStack trace:\n{ex.StackTrace}");

                return StatusCode(500, "Server error. An unknown error occurred on the server..");
            }
        }

        // GET: api/Order/GetAllOrders
        //[Authorize]
        [HttpGet]
        [Route("GetAllHistoricOrders")]
        public ActionResult<List<OrderDTO>> GetAllHistoricOrders()
        {
            try
            {
                List<OrderDTO> result = _orderService.GetAllHistoricOrders();

                if (result == null)
                {
                    return StatusCode(500,
                        "Failed to retrieve all historic orders details from the database. If this error presists contact administrator");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                 new EventId((int)LogEventIdEnum.UnknownError),
                 $"Unexpected exception was caught in OrderController at GetAllHistoricOrders() .\nException:\n{ex.Message}\nInner exception:\n{ex.InnerException}\nStack trace:\n{ex.StackTrace}");

                return StatusCode(500, "Server error. An unknown error occurred on the server..");
            }
        }

        //[Authorize]
        [HttpGet]
        [Route("GetAllOrdersCount")]
        public ActionResult<int> GetAllOrdersCount()
        {
            try
            {
                int result = _orderService.GetAllOrdersCount();

                if (result == -1)
                {
                    return StatusCode(500,
                        "Failed to retrieve all orders count from the database. If this error presists contact administrator");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                 new EventId((int)LogEventIdEnum.UnknownError),
                 $"Unexpected exception was caught in OrderController at GetAllOrdersCount() .\nException:\n{ex.Message}\nInner exception:\n{ex.InnerException}\nStack trace:\n{ex.StackTrace}");

                return StatusCode(500, "Server error. An unknown error occurred on the server..");
            }
        }

        // POST api/Order/AddOrder? AddNewOrderDTO
        //[Authorize]
        [HttpPost]
        [Route("AddOrderByStaff")]
        public ActionResult<bool> AddNewOrder(AddNewOrderDTO order)
        {
            try
            {
                bool result = _orderService.AddNewOrderByStaff(order);

                if (!result)
                {
                    return StatusCode(500,
                        "Failed to add new order to the database. If this error presists contact administrator");
                }

                return Ok(result);
            }
            catch (OrderExistsException)
            {
                return StatusCode(400, "User already exists in the database. Try again with different values.");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                 new EventId((int)LogEventIdEnum.UnknownError),
                 $"Unexpected exception was caught in OrderController at AddNewOrder() .\nException:\n{ex.Message}\nInner exception:\n{ex.InnerException}\nStack trace:\n{ex.StackTrace}");

                return StatusCode(500, "Server error. An unknown error occurred on the server..");
            }
        }

        // DELETE api/<OrderController>/5
        //  [Authorize]
        [HttpDelete]
        [Route("CancelOrder")]
        public ActionResult<bool> DeletOrder([FromHeader] string OrderId)
        {
            try
            {
                bool result = _orderService.DeleteOrder(OrderId);

                if (!result)
                {
                    return StatusCode(500,
                        "Failed to remove existing order from the database. If this error presists contact administrator.");
                }

                return Ok(result);
            }
            catch (DataNotFoundException)
            {
                return StatusCode(400, "Order selected to remove does not exists in the database.Try to refresh your browser.If this error presists contact administrator.");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                 new EventId((int)LogEventIdEnum.UnknownError),
                 $"Unexpected exception was caught in OrderController at DeletOrder() .\nException:\n{ex.Message}\nInner exception:\n{ex.InnerException}\nStack trace:\n{ex.StackTrace}");

                return StatusCode(500, "Server error. An unknown error occurred on the server..");
            }
        }

        // PATCH api/Order/UpdateOrderStatus? OrderDTO
        //[Authorize]
        [HttpPatch]
        [Route("UpdateOrderStatus")]
        public ActionResult<bool> UpdateOrderStatus([FromBody] OrderStatusDTO order)
        {
            try
            {
                bool result = _orderService.UpdateOrderStatus(order.OrderId, order.OrderStatus);

                if (!result)
                {
                    return StatusCode(500,
                        "Failed to update order status to the database. If this error presists contact administrator.");
                }

                return Ok(result);
            }
            catch (DataNotFoundException)
            {
                return StatusCode(400, "Order selected to update does not exists in the database.Try to refresh your browser.If this error presists contact administrator.");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                 new EventId((int)LogEventIdEnum.UnknownError),
                 $"Unexpected exception was caught in OrderController at RemoveExistingUser() .\nException:\n{ex.Message}\nInner exception:\n{ex.InnerException}\nStack trace:\n{ex.StackTrace}");

                return StatusCode(500, "Server error. An unknown error occurred on the server..");
            }
        }

        // PATCH api/Order/UpdateOrderStatus? OrderDTO
        //[Authorize]
        [HttpPatch]
        [Route("UpdateOrderDeliveryDate")]
        public ActionResult<bool> UpdateOrderDeliveryDate([FromBody] ScheduledOrderDTO order)
        {
            try
            {
                bool result = _orderService.UpdateOrderDeliveryDate(order.OrderId, order.DeliveryDate);

                if (!result)
                {
                    return StatusCode(500,
                        "Failed to update order scheduled delivery date to the database. If this error presists contact administrator.");
                }

                return Ok(result);
            }
            catch (DataNotFoundException)
            {
                return StatusCode(400, "Order selected to update does not exists in the database.Try to refresh your browser.If this error presists contact administrator.");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                 new EventId((int)LogEventIdEnum.UnknownError),
                 $"Unexpected exception was caught in OrderController at UpdateOrderDeliveryDate() .\nException:\n{ex.Message}\nInner exception:\n{ex.InnerException}\nStack trace:\n{ex.StackTrace}");

                return StatusCode(500, "Server error. An unknown error occurred on the server..");
            }
        }
    }
}
