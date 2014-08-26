using System;
using System.Collections.Generic;

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
        public virtual List<ItemStock> ItemStocks { get; protected set; }
    }
}