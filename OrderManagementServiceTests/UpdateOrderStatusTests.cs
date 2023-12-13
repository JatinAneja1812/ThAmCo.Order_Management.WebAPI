using AutoMapper;
using DomainObjects.Orders;
using Enums;
using Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Interfaces;
using ThAmCo.Order_Management.WebAPI.Repositories.Interfaces;
using ThAmCo.Order_Management.WebAPI.Services.Classes;
using Xunit;

namespace OrderManagementServiceTests
{
    public class UpdateOrderStatusTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<ILogger<OrderService>> _logger;
        private readonly Mock<IGuidUtility> _guidUtility;
        private readonly Mock<IMapper> _mapper;
        private readonly OrderService _orderService;

        public UpdateOrderStatusTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _logger = new Mock<ILogger<OrderService>>();
            _guidUtility = new Mock<IGuidUtility>();
            _mapper = new Mock<IMapper>();

            _orderService = new OrderService(_orderRepository.Object, _guidUtility.Object, _logger.Object, _mapper.Object);
        }

        [Fact]
        public void UpdateOrderStatus_Should_Update_Status_And_Return_True()
        {
            // Arrange
            var orderId = "1";
            var orderStatus = OrderStatusEnum.Processing;

            var existingOrder = new Order
            {
                OrderId = orderId,
                Status = OrderStatusEnum.Waiting,
                IsArchived = false
                // ... other order properties
            };
            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns(existingOrder);

            _orderRepository.Setup(repo => repo.UpdateOrderToDatabase(existingOrder))
                .Returns(1); // Assuming 1 means successful update in your repository method

            // Act
            var result = _orderService.UpdateOrderStatus(orderId, orderStatus);

            // Assert
            Assert.True(result);
            Assert.Equal(orderStatus, existingOrder.Status);
            _orderRepository.Verify(repo => repo.UpdateOrderToDatabase(existingOrder), Times.Once);
        }

        [Fact]
        public void UpdateOrderStatus_Should_Set_IsArchived_To_True_If_Status_Is_Delivered()
        {
            // Arrange
            var orderId = "1";
            var orderStatus = OrderStatusEnum.Delivered;

            var existingOrder = new Order
            {
                OrderId = orderId,
                Status = OrderStatusEnum.Processing,
                IsArchived = false
                // ... other order properties
            };

            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns(existingOrder);

            _orderRepository.Setup(repo => repo.UpdateOrderToDatabase(existingOrder))
                .Returns(1); // Assuming 1 means successful update in your repository method

            // Act
            _orderService.UpdateOrderStatus(orderId, orderStatus);

            // Assert
            Assert.True(existingOrder.IsArchived);
            Assert.Equal(orderStatus, existingOrder.Status);
        }

        [Fact]
        public void UpdateOrderStatus_Should_Return_False_If_Update_Fails()
        {
            // Arrange
            var orderId = "1";
            var orderStatus = OrderStatusEnum.Processing;

            var existingOrder = new Order
            {
                OrderId = orderId,
                Status = OrderStatusEnum.Waiting,
                IsArchived = false
                // ... other order properties
            };

            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns(existingOrder);

            _orderRepository.Setup(repo => repo.UpdateOrderToDatabase(existingOrder))
                .Returns(0); // Assuming 0 means update failure in your repository method

            // Act
            var result = _orderService.UpdateOrderStatus(orderId, orderStatus);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UpdateOrderStatus_Should_Throw_DataNotFoundException_If_Order_Not_Found()
        {
            // Arrange
            var orderId = "1";
            var orderStatus = OrderStatusEnum.Processing;

            _orderRepository.Setup(repo => repo.GetOrderByIdFromDatabase(orderId))
                .Returns((Order)null); // Simulate order not found in the repository

            // Act & Assert
            Assert.Throws<DataNotFoundException>(() => _orderService.UpdateOrderStatus(orderId, orderStatus));
            _orderRepository.Verify(repo => repo.UpdateOrderToDatabase(It.IsAny<Order>()), Times.Never);
        }
    }
}
