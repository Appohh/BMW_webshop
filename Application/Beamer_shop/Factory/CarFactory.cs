using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class CarFactory
    {
      public static CarService CarService { get; } =
    new CarService(new CarRepository());
    }
}
