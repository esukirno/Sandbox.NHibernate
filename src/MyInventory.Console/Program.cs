using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using MyInventory.Model;
using NHibernate;
using NHibernate.Dialect;

namespace MyInventory.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            
            var sessions = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.
                        ShowSql()
                        .ConnectionString("Server=localhost;Database=MyInventory;Trusted_Connection=True;"))                
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<Warehouse>()                    
                    .Conventions.Add(
                        PrimaryKey.Name.Is(x => "Id"),
                        DefaultLazy.Always(),
                        ForeignKey.EndsWith("Id")
                    ))                    
                .BuildSessionFactory();


            var se = sessions.OpenSession();


        }
    }
}
