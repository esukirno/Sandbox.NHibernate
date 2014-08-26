using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MyInventory.Infrastructure.Configurations;
using MyInventory.Infrastructure.Configurations.Maps;
using MyInventory.Model;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace MyInventory.Console
{
    /// <summary>
    /// Print out database create sql statements    
    /// </summary>
    class Program
    {
        /* Set database connection string here */
        private const string ConnectionString = "Server=localhost;Database=SandboxNHibernate;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            var sql = GetNHibernateConfiguration()
                .ExposeConfiguration(c => new SchemaExport(c).Execute(true, true, false))
                .BuildConfiguration()
                .GenerateSchemaCreationScript(new MsSql2012Dialect());
            
            Print(sql);
        }

        static void Print(string[] lines)
        {
            foreach (var line in lines)
            {
                if (line.GetType() != typeof(string))
                {
                    
                }
                System.Console.WriteLine(line);
            }
        }

        private static FluentConfiguration GetNHibernateConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012
                        .ConnectionString(ConnectionString)
                        .ShowSql())
                .Mappings(m =>
                {
                    RegisterAutoMapping(m);
                    RegisterFluentMappings(m);
                });
        }

        private static void RegisterFluentMappings(MappingConfiguration m)
        {
            m.FluentMappings.AddFromAssemblyOf<ItemMap>(); /* To tell NHibernate the location of class maps */
        }

        private static void RegisterAutoMapping(MappingConfiguration m)
        {
            /* Here we use SandboxAutoMappingConfiguration class */
            var config = AutoMap.AssemblyOf<Warehouse>(new SandboxAutoMappingConfiguration())
                .Conventions.Setup(
                c =>
                {
                    c.Add<PrimaryKeyNameConvention>();
                    c.Add<ForeignKeyNameConvention>();
                    c.Add<ForeignKeyConstraintNameConvention>();
                    c.Add<DefaultTableNameConvention>();
                });
            m.AutoMappings.Add(config);
        }
    }

    /// <summary>
    /// This will tell NHibernate to only map classes that is a subclass of BaseModel and is not abstract class
    /// </summary>
    public class SandboxAutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.IsSubclassOf(typeof(BaseModel)) && !type.IsAbstract;
        }
    }    
}
