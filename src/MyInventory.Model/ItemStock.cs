using System;

namespace MyInventory.Model
{
    public class ItemStock
    {
        public virtual Guid Id { get; protected set; }
        public virtual Inventory Inventory { get; protected set; }
        public virtual Item Item { get; protected set; }
        public virtual int Quantity { get; protected set; }
    }
}