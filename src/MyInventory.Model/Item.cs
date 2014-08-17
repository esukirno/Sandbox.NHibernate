using System;

namespace MyInventory.Model
{
    public class Item
    {
        public virtual Guid Id { get; protected set; }
        public virtual string SKU { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual decimal CostPrice { get; protected set; }
        public virtual decimal RetailPrice { get; protected set; }

        public Item(Guid id, string sku, string name, string description, decimal costPrice, decimal retailPrice)
        {
            Id = id;
            SKU = sku;
            Name = name;
            Description = description;
            CostPrice = costPrice;
            RetailPrice = retailPrice;

        }
    }
}