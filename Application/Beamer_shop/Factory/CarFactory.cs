using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class AccessoryFactory
    {
      public static AccessoryService AccessoryService { get; } =
    new AccessoryService(new AccessoryRepository());
    }
}
