using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace MyInventory.Infrastructure.Configurations
{
    public class PrimaryKeyNameConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column("Id");
        }
    }
}