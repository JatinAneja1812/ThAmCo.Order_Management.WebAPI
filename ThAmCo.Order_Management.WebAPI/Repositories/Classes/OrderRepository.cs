using DataContext;
using DomainObjects.Address;
using DomainObjects.Orders;
using Enums;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Classes
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
                                        .Where(order => order.IsArchived == false && order.IsDeleted == false)
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

        public Order GetOrderByIdFromDatabase(string orderId)
        {
            try
            {
                Order order = _context.Orders
                                    .Include(m => m.OrderedItems)
                                    .Include(m => m.Customer)
                                    .Include(m => m.ShippingAddress)
                                    .Include(m => m.BillingAddress)
                                    .Where(order => order.OrderId == orderId)
                                    .First();
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.GetFailed),
                   $"Failed to retrive order with order id {orderId} from the database. Error occurred in Order Repository at GetOrderByIdFromDatabase(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return null;
            }
        }
        public List<Order> GetAllHistoricOrdersFromDatabase()
        {
            try
            {
                List<Order> orderList = _context.Orders
                                        .Include(m => m.OrderedItems)
                                        .Include(m => m.Customer)
                                        .Include(m => m.ShippingAddress)
                                        .Include(m => m.BillingAddress)
                                        .Where(order => order.IsArchived == true && order.IsDeleted == false)
                                        .ToList();
                return orderList;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.GetFailed),
                   $"Failed to retrive all historic orders list from the database. Error occurred in Order Repository at GetAllHistoricOrdersFromDatabase(...) with the following message and stack trace: " +
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
                   $"Failed to retrive billing address from the database. Error occurred in Order Repository at GetBillingAddressByCriteria(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return null;
            }
        }

        public int GetOrdersCountFromDatabase()
        {
            try
            {
                return _context.Orders.Where(o => o.IsArchived == false && o.IsDeleted == false).ToList().Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.GetFailed),
                   $"Failed to retrive orders count from the database. Error occurred in Order Repository at GetOrdersCountFromDatabase(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return -1;
            }
        }

        public int DeleteOrderFromDatabase(Order orderToDelete)
        {
            try
            {
                // SoftDelete
                orderToDelete.IsDeleted = true;
                _context.Orders.Update(orderToDelete);
                _context.ChangeTracker.DetectChanges();
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.GetFailed),
                   $"Failed to remove orders from the database. Error occurred in Order Repository at DeleteOrderFromDatabase(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return -1;
            }
        }

        public int UpdateOrderToDatabase(Order orderToUpdate)
        {
            try
            {
                _context.Orders.Update(orderToUpdate);
                _context.ChangeTracker.DetectChanges();
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   new EventId((int)LogEventIdEnum.GetFailed),
                   $"Failed to update orders to the database. Error occurred in Order Repository at UpdateOrderToDatabase(...) with the following message and stack trace: " +
                   $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}"
                  );

                return -1;
            }
        }
    }
}
