using DomainDataObjects.Address;
using DomainDataObjects.Orders;

namespace Repository.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrdersFromDatabase();
        public Order GetOrderByIDFromDatabase(string orderId);
        public int AddNewOrderToDatabase(Order orderToAdd);
        public BillingAddress GetBillingAddressByCriteria(BillingAddress billingAddress);

        public int AddBillingAddressToDatabase(BillingAddress billingAddress);
    }
}
