using Geocoding;
using GoogleMaps.LocationServices;
using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class ShippingCalculator : IShippingCalculator
    {
        public int Distance { get; private set; }
        public Tuple<int, int> EstimatedDeliveryTime { get; private set; }
        public double TotalShippingCost { get; private set; }

        private int totalWeight;
        private int totalCars;
        private double MinimalCost;
        private double FuelPerLiter;
        private string WarehouseAdress;
        private string ShippingAddress;
        private IShoppingCart _shoppingCart;

        public ShippingCalculator(string shippingAddress, IShoppingCart shoppingCart)
        {
            ShippingAddress = shippingAddress;
            _shoppingCart = shoppingCart;

            if (!retrieveData())
            {
                throw new Exception("Failed to retrieve data.");
            }

            if (_shoppingCart.GetItems().Count < 1)
            {
                throw new Exception("Cart is empty.");
            }

            CalculateDistance();
            CalculateShippingWeight();
            CalculateDeliveryTime();
            CalculateShippingCost();

        }

        private bool retrieveData()
        {
            WarehouseAdress = "Panningen";
            MinimalCost = 200;
            FuelPerLiter = 1.81;
            return true;

        }

        private void CalculateDistance()
        {
            Distance = 400;
        }

        private void CalculateShippingWeight()
        {
            foreach (var item in _shoppingCart.GetItems())
            {
                if (item.Product is Car car)
                {
                    totalWeight += car.Weight * item.Quantity;
                    totalCars += item.Quantity;
                }
                else if (item.Product is Accessory accessory)
                {
                    totalWeight += accessory.Weight * item.Quantity;
                }
            }
         
        }

        private void CalculateDeliveryTime()
        {
            int minimalDays;
            int maximalDays;

            if (totalCars > 0)
            {

                if (totalCars == 1)
                {
                    minimalDays = 5 + Distance / 100;
                    maximalDays = 12 + Distance / 100;
                }
                else
                {
                    minimalDays = 10 + Distance / 200;
                    maximalDays = 20 + Distance / 200;
                }
            }
            else
            {
                if (totalWeight > 500)
                {
                    minimalDays = 3;
                    maximalDays = 6;
                }
                else
                {
                    minimalDays = 1;
                    maximalDays = 3;
                }
            }
            EstimatedDeliveryTime = Tuple.Create(minimalDays, maximalDays);
        }

        private void CalculateShippingCost()
        {



            double shippingCost = (FuelPerLiter * 0.2 * Distance * totalWeight)  / 6501.248 + MinimalCost;

            TotalShippingCost = Math.Round(shippingCost, 2);

        }





    }
}
