using DomainObjects.Address;
using DomainObjects.Orders;

namespace Repositories.Interfaces
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

        public int DeleteOrderFromDatabase(Order orderToDelete);
    }
}
