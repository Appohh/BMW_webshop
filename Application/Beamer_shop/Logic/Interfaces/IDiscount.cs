using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IDiscount
    {
        double CalculateDiscount();
        bool IsApplicable(Order order);
        double ApplyDiscount(Order order);
    }
}
