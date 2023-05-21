using Logic.Interfaces;

namespace Data
{
    public interface IDiscountRepository
    {
        List<IDiscount> GetAllActiveDiscounts();
        List<IDiscount> GetAllDiscounts();
        void refreshDiscountData();
    }
}