using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICouponDiscount : IDiscount
    {
        string CouponCode { get; }
        int Percentage { get; }
        double MinimalSpend { get; }
        double MaxDiscount { get; }
        

    }
}
