using System;
using System.Collections.Generic;

namespace MyInventory.Model
{
    public class Inventory
    {
        public virtual Guid Id { get; protected set; }
        public virtual Guid WarehouseId { get; protected set; }
        public virtual List<ItemStock> ItemStocks { get; protected set; }
    }
}