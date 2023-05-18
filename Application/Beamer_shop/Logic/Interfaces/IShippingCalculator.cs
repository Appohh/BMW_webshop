namespace Logic.Interfaces
{
    public interface IShippingCalculator
    {
        int Distance { get; }
        Tuple<int, int> EstimatedDeliveryTime { get; }
        double TotalShippingCost { get; }
    }
}