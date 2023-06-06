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
        public void CalculateShippingCost_200()
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

        [TestMethod]
        public void Coupon50Percentage()
        {
            // Arrange
            IShoppingCart cart = new ShoppingCart();
            Product accesory = new Accessory("Part", 1, "", 100, "", "", "", 21, 70);
            cart.AddItem(accesory);

            Address address = new Address("", "", "", "", "");

            Order order = new Order(cart, 3, 0, 0, 0, address, 0);

            List<IDiscount> discounts = new List<IDiscount>();
            
            IDiscount discount = new CouponDiscount("code", 50, 1, 60);
            discounts.Add(discount);

            // Act
            order.CalculateTotalTax();
            order.CalculateTotalTotal();
            order.ApplyDiscounts(discounts, "code");

            // Assert
            double expectedDiscount = 50;
            Assert.AreEqual(expectedDiscount, order.Discount);

        }
    }
}