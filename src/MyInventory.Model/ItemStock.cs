using System;
using MyInventory.Exceptions;

namespace MyInventory.Model
{
    public class ItemStock
    {
        public virtual Guid InventoryId { get; protected set; }
        public virtual Guid ItemId { get; protected set; }
        public virtual int Quantity { get; protected set; }

        public ItemStock(Guid inventoryId, Guid itemId, int quantity)
        {
            InventoryId = inventoryId;
            ItemId = itemId;
            Quantity = quantity;
        }

        public virtual void Replenish(int quantity)
        {
            Quantity += quantity;
        }

        public virtual void Destock(int quantity)
        {
            if (Quantity < quantity)
                throw new InsufficientQuantityException();
            Quantity -= quantity;
        }
    }
}