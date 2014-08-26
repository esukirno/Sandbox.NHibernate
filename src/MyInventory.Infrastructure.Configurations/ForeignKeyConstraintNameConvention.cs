using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace MyInventory.Infrastructure.Configurations
{
    public class ForeignKeyConstraintNameConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Key.ForeignKey(string.Format("{0}_{1}_FK", instance.Member.Name, instance.EntityType.Name));
        }
    }
}