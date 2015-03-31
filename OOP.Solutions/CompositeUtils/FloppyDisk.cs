using System;

namespace OOP.Solutions.CompositeUtils
{
    public  class FloppyDisk:Equipment
    {
        private readonly string name;
        private readonly decimal netPrice;
        private readonly decimal discountPrice;

        public override string Name
        {
            get { return name; }
        }

        public override decimal DiscountPrice
        {
            get { return discountPrice; }
        }

        public override decimal NetPrice
        {
            get { return netPrice; }
        }

        public FloppyDisk(string name, Decimal netPrice, Decimal discountPrice)
        {
            this.name = name;
            this.netPrice = netPrice;
            this.discountPrice = discountPrice;
        }
    }
}
