using DomainDataObjects.Address;
using DomainDataObjects.Orders;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using ThAmCo.Orders.DataContext;

namespace Repository.Classes
{
    public class OrderRepository : IOrderRepository
    {

        private readonly OrdersContext _context;
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository(OrdersContext OrdersContext, ILogger<OrderRepository> Logger)
        {
            _context = OrdersContext;
            _logger = Logger;
        }

        public int AddBillingAddressToDatabase(BillingAddress billingAddress)
        {
            try
            {
                _context.BillingAddresses.Add(billingAddress);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.InsertFailed),
                   $"Failed to billing address to the database. Error occurred in Orders Repository at AddBillingAddressToDatabase(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return -1;
            }
        }

        public int AddNewOrderToDatabase(Order orderToAdd)
        {
            try
            {
                _context.Orders.Add(orderToAdd);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.InsertFailed),
                   $"Failed to add order with orderID: {orderToAdd.OrderId} to the database. Error occurred in Orders Repository at AddNewOrderToDatabase(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return -1;
            }
        }

        public List<Order> GetAllOrdersFromDatabase()
        {
            try
            {
                List<Order> orderList = _context.Orders
                                        .Include(m => m.OrderedItems)
                                        .Include(m => m.Customer)
                                        .Include(m => m.ShippingAddress)
                                        .Include(m => m.BillingAddress)
                                        .ToList();
                return orderList;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.GetFailed),
                   $"Failed to retrive orders list from the database. Error occurred in Order Repository at GetAllOrdersFromDatabase(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return null;
            }
        }

        public BillingAddress GetBillingAddressByCriteria(BillingAddress billingAddress)
        {
            try
            {
                return _context.BillingAddresses.Where(m => m.BillingAddresssID == billingAddress.BillingAddresssID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.GetFailed),
                   $"Failed to retrive billing address from the database. Error occurred in Order Repository at GetAllOrdersFromDatabase(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return null;
            }
        }

        public Order GetOrderByIDFromDatabase(string orderId)
        {
            try
            {
                Order order = _context.Orders
                                    .Where(c => c.OrderId == orderId)
                                    .Include(m => m.OrderedItems)
                                    .Include(m => m.Customer)
                                    .Include(m => m.ShippingAddressId)
                                    .Include(m => m.BillingAddress).First();

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.GetFailed),
                   $"Failed to order with and orderId: {orderId} from the database. Error occurred in Order Repository at GetOrderByIDFromDatabase(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return null;
            }
        }
    }
}
