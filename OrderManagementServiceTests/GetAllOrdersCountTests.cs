using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Interfaces;
using ThAmCo.Order_Management.WebAPI.Repositories.Interfaces;
using ThAmCo.Order_Management.WebAPI.Services.Classes;
using Xunit;

namespace OrderManagementServiceTests
{
    public class GetAllOrdersCountTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<ILogger<OrderService>> _logger;
        private readonly Mock<IGuidUtility> _guidUtility;
        private readonly Mock<IMapper> _mapper;
        private readonly OrderService _orderService;

        public GetAllOrdersCountTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _logger = new Mock<ILogger<OrderService>>();
            _guidUtility = new Mock<IGuidUtility>();
            _mapper = new Mock<IMapper>();

            _orderService = new OrderService(_orderRepository.Object, _guidUtility.Object, _logger.Object, _mapper.Object);
        }

        [Fact]
        public void GetAllOrdersCount_Should_Return_Negative_1_When_NoOrdersFound()
        {
            // Arrange
            var expectedCount = -1;
            _orderRepository.Setup(repo => repo.GetOrdersCountFromDatabase())
                .Returns(-1); // Simulating no orders found

            // Act
            var result = _orderService.GetAllOrdersCount();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void GetAllOrdersCount_Should_Throw_Exception_When_Repository_Fails()
        {
            // Arrange
            _orderRepository.Setup(repo => repo.GetOrdersCountFromDatabase())
                .Throws(new Exception("Simulated repository exception"));

            // Act & Assert
            Assert.Throws<Exception>(() => _orderService.GetAllOrdersCount());
        }

        [Fact]
        public void GetAllOrdersCount_Should_Return_Actual_Count_Order()
        {
            // Arrange

            _orderRepository.Setup(repo => repo.GetOrdersCountFromDatabase())
                .Returns(2);

            // Act
            var result = _orderService.GetAllOrdersCount();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result);
        }
    }
}
