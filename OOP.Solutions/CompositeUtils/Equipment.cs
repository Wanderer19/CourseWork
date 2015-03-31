namespace OOP.Solutions.CompositeUtils
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
