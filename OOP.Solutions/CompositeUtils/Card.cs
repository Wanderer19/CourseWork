﻿using System;
using OOP.Solutions.CompositeUtils;

namespace OOP.Implementation.CompositeUtils
{
    public sealed class Card:CompositeEquipment
    {
        private readonly string name;

        public override string Name
        {
            get { return name; }
        }

        public Card(string name, Decimal netPrice, Decimal discountPrice)
        {
            this.name = name;
            this.netPrice = netPrice;
            this.discountPrice = discountPrice;
        }
    }
}
