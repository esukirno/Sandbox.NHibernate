using System;

namespace MyInventory.Model
{
    public class Inventory
    {
        public virtual Guid Id { get; protected set; }
        public virtual Guid WarehouseId { get; protected set; }

        public Inventory(Guid id, Guid warehouseId)
        {
            Id = id;
            WarehouseId = warehouseId;
        }

        public virtual void IntroduceItem(Item item, int initialQuantity, Action<Inventory, Item, int> stockItem)
        {
            stockItem(this, item, initialQuantity);
        }
    }
}