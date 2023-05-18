using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateShippingCost_TotalWeightLessThan500_ReturnsCorrectShippingCost()
        {
            // Arrange
            string shippingAddress = "Some address";
            var shoppingCartMock = new Mock<IShoppingCart>();
            var itemMock = new Mock<CartItem>();
            var accessoryMock = new Mock<Accessory>();
            accessoryMock.Setup(a => a.Weight).Returns(100); // Mocking accessory weight
            itemMock.Setup(i => i.Product).Returns(accessoryMock.Object);
            itemMock.Setup(i => i.Quantity).Returns(2); // Setting quantity to 2
            shoppingCartMock.Setup(c => c.GetItems()).Returns(new[] { itemMock.Object });

            var calculator = new ShippingCalculator(shippingAddress, shoppingCartMock.Object);

            // Act
            decimal shippingCost = calculator.TotalShippingCost;

            // Assert
            decimal expectedShippingCost = 100m; // weightFactor: 0.1 * totalWeight: 200 + distanceFactor: 4 * MinimalCost: 200 * FuelPerLiter: 1.81
            Assert.AreEqual(expectedShippingCost, shippingCost);
        }

    }
}
