using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Implementation.CompositeUtils
{
    public class Chassis: CompositeEquipment
    {
        private readonly string name;

        public override string Name
        {
            get { return name; }
        }

        public Chassis(string name, Decimal netPrice, Decimal discountPrice)
        {
            this.name = name;
            this.netPrice = netPrice;
            this.discountPrice = discountPrice;
        }
    }
}
