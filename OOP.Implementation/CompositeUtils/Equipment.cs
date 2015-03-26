using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Implementation.CompositeUtils
{
    public abstract class Equipment
    {
        public abstract string Name { get; }
        public abstract decimal NetPrice { get; }
        public abstract decimal DiscountPrice { get; }

        public virtual void Add(Equipment equipment)
        {
            
        }

        public virtual void Remove(Equipment equipment)
        {
            
        }
    }
}
