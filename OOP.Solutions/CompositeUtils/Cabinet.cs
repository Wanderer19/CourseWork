using System;

namespace OOP.Solutions.CompositeUtils
{
    public sealed class Cabinet :CompositeEquipment
    {
        private readonly string name;

        public override string Name
        {
            get { return name; }
        }

        public Cabinet(string name, Decimal netPrice, Decimal discountPrice)
        {
            this.name = name;
            this.netPrice = netPrice;
            this.discountPrice = discountPrice;
        }
    }
}
