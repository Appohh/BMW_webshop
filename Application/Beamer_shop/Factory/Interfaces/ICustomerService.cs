using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Interfaces
{
    public interface ICustomerFactory
    {
        ICustomerService CustomerService { get; }
    }
}
