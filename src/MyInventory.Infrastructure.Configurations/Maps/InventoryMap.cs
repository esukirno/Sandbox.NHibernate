using FluentNHibernate.Mapping;
using MyInventory.Model;

namespace MyInventory.Infrastructure.Configurations.Maps
{
    public class InventoryMap : ClassMap<Inventory>
    {
        public InventoryMap()
        {
            Table("Inventory");
            Id(x => x.Id);
            Map(x => x.WarehouseId);
            HasMany(x => x.ItemStocks).Cascade.All().Fetch.Join().Inverse().KeyColumn("InventoryId");
        }
    }
}