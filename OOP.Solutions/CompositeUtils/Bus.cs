using System;

namespace OOP.Solutions.CompositeUtils
{
    public sealed class Bus:CompositeEquipment
    {
       private readonly string name;

        public override string Name
        {
            get { return name; }
        }

        public Bus(string name, Decimal netPrice, Decimal discountPrice)
        {
            this.name = name;
            this.netPrice = netPrice;
            this.discountPrice = discountPrice;
        }
    }
}
