using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using NHibernate.Mapping;
using ForeignKey = FluentNHibernate.Conventions.Helpers.ForeignKey;

namespace MyInventory.Infrastructure.Configurations
{
    public class DefaultTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name);
        }
    }
}
