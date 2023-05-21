using Logic.Interfaces;

namespace Logic
{
    public interface IDiscountService
    {
        List<IDiscount> GetAllActiveDiscounts();
        List<IDiscount> GetAllDiscounts();
    }
}