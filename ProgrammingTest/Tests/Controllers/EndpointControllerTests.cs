using ProgrammingTest.Controllers;
using ProgrammingTest.Interfaces;
using ProgrammingTest.Models;
using Moq;
using Xunit;

namespace ProgrammingTest.Tests.Controllers
{
    public class EndpointControllerTests
    {
        private readonly Mock<IEndpointService> _mockService;
        private readonly EndpointController _controller;

        public EndpointControllerTests()
        {
            _mockService = new Mock<IEndpointService>();
            _controller = new EndpointController(_mockService.Object);
        }
        
        private static Endpoint CreateTestEndpoint()
        {
            return new Endpoint
            {
                EndpointSerialNumber = "NSX1P2W",
                MeterModelId = 111,
                MeterNumber = 222,
                MeterFirmwareVersion = "1.0.3",
                SwitchState = 2
            };
        }

        [Fact]
        public void AddEndpointShouldAssignFixedIntegerWhenSerialMatches()
        {
            var endpoint = CreateTestEndpoint();

            _controller.AddEndpoint(endpoint);

            Assert.Equal(16, endpoint.MeterModelId);
            _mockService.Verify(service => service.AddEndpoint(It.IsAny<Endpoint>()), Times.Once);
        }

        [Fact]
        public void AddEndpointShouldCallServiceIfSerialNumberDoesNotExist()
        {
            var endpoint = CreateTestEndpoint();

            _controller.AddEndpoint(endpoint);

            _mockService.Verify(service => service.AddEndpoint(It.IsAny<Endpoint>()), Times.Once);
        }

        [Fact]
        public void EditEndpointShouldCallServiceWhenEndpointExists()
        {
            var endpointSerialNumber = "NSX1P2W";
            var endpoint = CreateTestEndpoint();
            _mockService.Setup(service => service.FindEndpointBySerialNumber(endpointSerialNumber)).Returns(endpoint);
            
            var input = new StringReader("1\n");
            Console.SetIn(input);

            _controller.EditEndpoint(endpointSerialNumber);

            _mockService.Verify(service => service.EditEndpoint(endpoint, It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void ListAllEndpointsShouldReturnEmptyListIfNoEndpointsFound()
        {
            _mockService.Setup(service => service.ListAllEndpoints()).Returns(new List<Endpoint>());

            var result = _controller.ListAllEndpoints();

            Assert.Empty(result);
            _mockService.Verify(service => service.ListAllEndpoints(), Times.Once);
        }

        [Fact]
        public void FindEndpointBySerialNumberShouldReturnEndpointWhenSerialMatches()
        {
            var endpointSerialNumber = "NSX1P2W";
            var endpoint = CreateTestEndpoint();
            _mockService.Setup(service => service.FindEndpointBySerialNumber(endpointSerialNumber)).Returns(endpoint);

            var result = _controller.FindEndpointBySerialNumber(endpointSerialNumber);

            Assert.Equal(endpoint, result);
            _mockService.Verify(service => service.FindEndpointBySerialNumber(endpointSerialNumber), Times.Once);
        }
    }
}
