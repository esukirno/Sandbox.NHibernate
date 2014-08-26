using FluentNHibernate.Mapping;
using MyInventory.Model;

namespace MyInventory.Infrastructure.Configurations.Maps
{
    public class ItemStockMap : ClassMap<ItemStock>
    {
        public ItemStockMap()
        {
            Table("ItemStock");
            Id(x => x.Id);
            References(x => x.Item).Not.Nullable().Cascade.SaveUpdate().Column("ItemId");
            References(x => x.Inventory).Not.Nullable().Cascade.SaveUpdate().Column("InventoryId");
        }
    }
}