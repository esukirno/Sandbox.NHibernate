using FluentNHibernate.Mapping;
using MyInventory.Model;

namespace MyInventory.Infrastructure.Configurations.Maps
{
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Table("Item");
            Id(x => x.Id);
            Map(x => x.Description);
            Map(x => x.CostPrice);
            Map(x => x.Name);
            Map(x => x.RetailPrice);
            Map(x => x.SKU);
            HasMany(x => x.ItemStocks).Cascade.All().Fetch.Join().Inverse().KeyColumn("ItemId");
        }
    }
}