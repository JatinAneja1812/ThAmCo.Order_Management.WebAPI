using DomainObjects.Address;
using DomainObjects.Customer;
using DomainObjects.Orders;

namespace ThAmCo.Order_Management.WebAPI.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrdersFromDatabase();
        public Order GetOrderByIdFromDatabase(string orderId);
        public List<Order> GetAllHistoricOrdersFromDatabase();
        public int GetOrdersCountFromDatabase();
        public int AddNewOrderToDatabase(Order orderToAdd);
        public BillingAddress GetBillingAddressByCriteria(BillingAddress billingAddress);
        public int AddBillingAddressToDatabase(BillingAddress billingAddress);
        public Customer GetCustomerById(string customerId);
        public int AddCustomerToDatabase(Customer customer);
        public int DeleteOrderFromDatabase(Order orderToDelete);
        public int UpdateOrderToDatabase(Order orderToDelete);
    }
}
