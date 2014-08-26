using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace MyInventory.Infrastructure.Configurations
{
    public class ForeignKeyNameConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Key.Column(instance.EntityType.Name + "Id");
            
        }
    }
}