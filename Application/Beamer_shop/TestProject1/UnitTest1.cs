using Logic;
using Logic.Interfaces;
using Logic.Models;
using Moq;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateShippingCost_TotalWeightLessThan500_ReturnsCorrectShippingCost()
        {
            // Arrange
            IShoppingCart cart = new ShoppingCart();
            Product accesory = new Accessory("Part", 1, "", 12, "", "", "", 21, 70);
            cart.AddItem(accesory);

            string shippingAdress = "Eindhoven";



            var calculator = new ShippingCalculator(shippingAdress, cart);

            // Act
            double shippingCost = calculator.TotalShippingCost;

            // Assert
            double expectedShippingCost = 200;
            Assert.AreEqual(expectedShippingCost, shippingCost);
        }
    }
}