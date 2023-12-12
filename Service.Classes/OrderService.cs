using AutoMapper;
using DomainDataObjects.Address;
using DomainDataObjects.Customer;
using DomainDataObjects.Orders;
using DomainDTOs.Address;
using DomainDTOs.Customer;
using DomainDTOs.Order;
using Enums;
using Exceptions;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Classes
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGuidUtility _guidUtility;
        private readonly ILogger<OrderService> _logger;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository OrderRepository, IGuidUtility GuidUtility, ILogger<OrderService> Logger, IMapper Mapper)
        {
            _orderRepository = OrderRepository;
            _guidUtility = GuidUtility;
            _logger = Logger;
            _mapper = Mapper;
        }


        public bool AddNewOrderByStaff(AddNewOrderDTO orderDTO)
        {
            try
            {
                // Revert this
                orderDTO.BillingAddress = new CompanyDetailsDTO
                {
                    CompanyAddressId = "AY821Y",
                    CompanyName = "Three Amigos Cooperation",
                    ShopNumber = "433",
                    Street = "Corporate Avenue",
                    City = "MiddlesBrough",
                    Country = "United Kingdoms",
                    PostalCode = "TS12RU"
                };


                Order newOrder = _mapper.Map<AddNewOrderDTO, Order>(orderDTO);
                newOrder.OrderId = _guidUtility.GenerateShortGuid(Guid.NewGuid());
                newOrder.isCreatedByStaff = true;

                if (orderDTO.Customer == null || orderDTO.OrderedItems == null || orderDTO.Address == null || orderDTO.BillingAddress == null)
                {
                    throw new RequiredInformationMissingException();
                }

                Customer customer = _mapper.Map<CustomerDTO, Customer>(orderDTO.Customer);
                newOrder.Customer = customer;
                newOrder.CustomerId = orderDTO.CustomerId;

                ShippingAddress customerAddress = _mapper.Map<AddressDTO, ShippingAddress>(orderDTO.Address);
                newOrder.ShippingAddress = customerAddress;
                newOrder.ShippingAddressId = _guidUtility.GenerateShortGuid(Guid.NewGuid());
                newOrder.ShippingAddress.ShippingAddressID = newOrder.ShippingAddressId;

                BillingAddress companyAddress = _mapper.Map<CompanyDetailsDTO, BillingAddress>(orderDTO.BillingAddress);
                // Check if the billing address already exists
                BillingAddress existingBillingAddress = _orderRepository.GetBillingAddressByCriteria(companyAddress);

                if (existingBillingAddress != null)
                {
                    // Reuse existing billing address
                    newOrder.BillingAddress = existingBillingAddress;
                    newOrder.BillingAddressId = existingBillingAddress.BillingAddresssID;
                }
                else
                {
                    // Create a new billing address and save it to the database
                    newOrder.BillingAddress = companyAddress;
                    newOrder.BillingAddressId = companyAddress.BillingAddresssID; // _guidUtility.GenerateShortGuid(Guid.NewGuid());
                    newOrder.BillingAddress.BillingAddresssID = newOrder.BillingAddressId;

                    _orderRepository.AddBillingAddressToDatabase(newOrder.BillingAddress);
                }

                newOrder.Status = OrderStatusEnum.Created;
                newOrder.IsArchived = false;
                ICollection<OrderItem> orderItems = _mapper.Map<ICollection<OrderItemDTO>, ICollection<OrderItem>>(orderDTO.OrderedItems);
                newOrder.OrderedItems = orderItems;

                int didSave = _orderRepository.AddNewOrderToDatabase(newOrder);

                return didSave > 0;
            }
            catch (RequiredInformationMissingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId((int)LogEventIdEnum.InsertFailed), $"Failed to add new order to the database. \nError occured in Orders Service at AddNewOrderByStaff(...) with following error message and stack trace." +
                 $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}");

                return false;
            }
        }

        public List<OrderDTO> GetAllOrders()
        {
            try
            {
                List<Order> allOrders = _orderRepository.GetAllOrdersFromDatabase();

                if (allOrders == null) // no user found
                {
                    return new List<OrderDTO>();
                }

                List<OrderDTO> ordersDTOs = _mapper.Map<List<Order>, List<OrderDTO>>(allOrders);

                return ordersDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId((int)LogEventIdEnum.GetFailed), $"Failed to retrieve all ordeers from the database. \nError occured in Orders Service at GetAllOrders(...) with following error message and stack trace." +
                 $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}");

                throw;
            }
        }

        public List<OrderDTO> GetAllHistoricOrders()
        {
            try
            {
                List<Order> allOrders = _orderRepository.GetAllHistoricOrdersFromDatabase();

                if (allOrders == null) // no user found
                {
                    return new List<OrderDTO>();
                }

                List<OrderDTO> ordersDTOs = _mapper.Map<List<Order>, List<OrderDTO>>(allOrders);

                return ordersDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId((int)LogEventIdEnum.GetFailed), $"Failed to retrieve all historic orders from the database. \nError occured in Orders Service at GetAllHistoricOrders(...) with following error message and stack trace." +
                 $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}");

                throw;
            }
        }

        public int GetAllOrdersCount()
        {
            try
            {
                int ordersCount = _orderRepository.GetOrdersCountFromDatabase();

                if (ordersCount == -1) // no orders found
                {
                    return -1;
                }

                return ordersCount;
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId((int)LogEventIdEnum.GetFailed), $"Failed to retrieve all ordeers count from the database. \nError occured in Orders Service at GetAllOrders(...) with following error message and stack trace." +
                 $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}");

                throw;
            }
        }


        public bool UpdateOrderStatus(string orderID, OrderStatusEnum orderStatus)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(string orderId)
        {
            try
            {
                Order existsingUser = _orderRepository.GetOrderByIdFromDatabase(orderId) ?? throw new DataNotFoundException();

                int didRemove = _orderRepository.DeleteOrderFromDatabase(existsingUser);

                return didRemove > 0;
            }
            catch (DataNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId((int)LogEventIdEnum.InsertFailed), $"Failed to delete existing order from the database. \nError occured in User Service at DeleteOrder(...) with following error message and stack trace." +
                 $"{ex.Message}\n{ex.StackTrace}\nInner exception: {(ex.InnerException != null ? ex.InnerException.Message + "\n" + ex.InnerException.StackTrace : "None")}");

                return false;
            }
        }
    }
}
