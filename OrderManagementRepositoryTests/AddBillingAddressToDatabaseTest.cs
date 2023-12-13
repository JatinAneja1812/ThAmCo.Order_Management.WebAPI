using DataContext;
using DomainObjects.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ThAmCo.Order_Management.WebAPI.Repositories.Classes;
using Xunit;

namespace OrderManagementRepositoryTests
{
    public class AddBillingAddressToDatabaseTest
    {
        private readonly OrderRepository _orderRepository;
        private readonly Mock<OrdersContext> _contextMock;
        private readonly Mock<ILogger<OrderRepository>> _loggerMock;

        public AddBillingAddressToDatabaseTest()
        {
            // Arrange
            _contextMock = new Mock<OrdersContext>();
            _loggerMock = new Mock<ILogger<OrderRepository>>();

            _orderRepository = new OrderRepository(_contextMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void AddBillingAddressToDatabase_Should_Add_Billing_Address_To_Database_If_Address_Does_Not_Exists_In_Database()
        {
            //Arrange
            Mock<DbSet<BillingAddress>> mockBillingAddressDbSet = new Mock<DbSet<BillingAddress>>();
            BillingAddress address = new BillingAddress
            {
                BillingAddresssID = "dedqw97qd",
                BillingAddresss_Shopname = "Company Name",
                BillingAddresss_Shopnumber = "789",
                BillingAddresss_Street = "Company Street",
                BillingAddresss_City = "Company City",
                BillingAddresss_Country = "Company Country",
                BillingAddresss_PostalCode = "67890"
            };

            var data = new List<BillingAddress>
            {
                new BillingAddress
                {
                    BillingAddresssID = "dedqw97qd",
                    BillingAddresss_Shopname = "Company Name23",
                    BillingAddresss_Shopnumber = "789321",
                    BillingAddresss_Street = "Smile Street",
                    BillingAddresss_City = "Some City",
                    BillingAddresss_Country = "Some Country",
                    BillingAddresss_PostalCode = "6789sda0"

                }
             }.AsQueryable();

            mockBillingAddressDbSet.As<IQueryable<BillingAddress>>().Setup(m => m.Provider).Returns(data.Provider);
            mockBillingAddressDbSet.As<IQueryable<BillingAddress>>().Setup(m => m.Expression).Returns(data.Expression);
            mockBillingAddressDbSet.As<IQueryable<BillingAddress>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockBillingAddressDbSet.As<IQueryable<BillingAddress>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _contextMock.SetupGet(c => c.BillingAddresses).Returns(mockBillingAddressDbSet.Object);

            //Act
            var res = _orderRepository.AddBillingAddressToDatabase(address);

            //Assert
            mockBillingAddressDbSet.Verify(m => m.Add(It.IsAny<BillingAddress>()), Times.Once);
            _contextMock.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void Should_Fail_If_Context_Returns_Null()
        {
            // Arrange
            Mock<DbSet<BillingAddress>> mockBillingAddressDbSet = new Mock<DbSet<BillingAddress>>();
            BillingAddress address = new BillingAddress
            {
                BillingAddresssID = "dedqw97qd",
                BillingAddresss_Shopname = "Company Name",
                BillingAddresss_Shopnumber = "789",
                BillingAddresss_Street = "Company Street",
                BillingAddresss_City = "Company City",
                BillingAddresss_Country = "Company Country",
                BillingAddresss_PostalCode = "67890"
            };

            _contextMock.SetupGet(c => c.BillingAddresses).Returns((DbSet<BillingAddress>)null); // Simulate _context.Users returning null

            var expected = _orderRepository.AddBillingAddressToDatabase(address);

            // Act and Assert
            Assert.Equal(expected, -1);
            mockBillingAddressDbSet.Verify(m => m.Add(It.IsAny<BillingAddress>()), Times.Never);
            _contextMock.Verify(m => m.SaveChanges(), Times.Never);
        }
    }
}
