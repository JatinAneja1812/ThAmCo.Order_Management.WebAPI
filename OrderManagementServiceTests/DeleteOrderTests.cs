using AutoMapper;
using DomainObjects.Orders;
using Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Interfaces;
using ThAmCo.Order_Management.WebAPI.Repositories.Interfaces;
using ThAmCo.Order_Management.WebAPI.Services.Classes;
using Xunit;

namespace OrderManagementServiceTests
{
    public class DeleteOrderTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<ILogger<OrderService>> _logger;
        private readonly Mock<IGuidUtility> _guidUtility;
        private readonly Mock<IMapper> _mapper;
        private readonly OrderService _orderService;

        public DeleteOrderTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _logger = new Mock<ILogger<OrderService>>();
            _guidUtility = new Mock<IGuidUtility>();
            _mapper = new Mock<IMapper>();

            _orderService = new OrderService(_orderRepository.Object, _guidUtility.Object, _logger.Object, _mapper.Object);
        }

        [Fact]
        public void DeleteOrder_Should_Return_True_If_Deletion_Successful()
        {
            // Arrange
            var orderId = "1";
            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns(new Order()); // Assume order exists in the repository

            _orderRepository.Setup(repo => repo.DeleteOrderFromDatabase(It.IsAny<Order>()))
                .Returns(1); // 1 means success in your repository method

            // Act
            var result = _orderService.DeleteOrder(orderId);

            // Assert
            Assert.True(result);
            _orderRepository.Verify(repo => repo.DeleteOrderFromDatabase(It.IsAny<Order>()), Times.Once);
        }

        [Fact]
        public void DeleteOrder_Should_Throw_DataNotFoundException_If_Order_Not_Found()
        {
            // Arrange
            var orderId = "1";
            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns((Order)null); // Simulate order not found in the repository

            // Act & Assert
            Assert.Throws<DataNotFoundException>(() => _orderService.DeleteOrder(orderId));
            _orderRepository.Verify(repo => repo.DeleteOrderFromDatabase(It.IsAny<Order>()), Times.Never);
        }

        [Fact]
        public void DeleteOrder_Should_Return_False_If_Deletion_Fails()
        {
            // Arrange
            var orderId = "1";
            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns(new Order()); // Assume order exists in the repository

            _orderRepository.Setup(repo => repo.DeleteOrderFromDatabase(It.IsAny<Order>()))
                .Returns(0); // Assuming 0 means failure in your repository method

            // Act
            var result = _orderService.DeleteOrder(orderId);

            // Assert
            Assert.False(result);
            _orderRepository.Verify(repo => repo.DeleteOrderFromDatabase(It.IsAny<Order>()), Times.Once);
        }
    }
}
