using System.Collections.Generic;
using System.Linq;
using OOP.Implementation.CompositeUtils;

namespace OOP.Solutions.CompositeUtils
{
    public abstract class CompositeEquipment:Equipment
    {
        private readonly List<Equipment> equipments = new List<Equipment>();
        protected decimal netPrice;
        protected decimal discountPrice;

        public override decimal DiscountPrice
        {
            get { return equipments.Sum(e => e.DiscountPrice) + discountPrice; }
        }

        public override decimal NetPrice
        {
            get
            {
                return equipments.Sum(e => e.NetPrice) + netPrice;
            }
        }

        public override void Add(Equipment equipment)
        {
            equipments.Add(equipment);
        }

        public override void Remove(Equipment equipment)
        {
            equipments.Remove(equipment);
        }
    }
}
