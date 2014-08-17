using System;

namespace MyInventory.Model
{
    public class Warehouse
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }

        public Warehouse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual void CreateInventory(Inventory inventory, Action<Warehouse, Inventory> createInventory)
        {
            createInventory(this, inventory);
        }
    }
}
