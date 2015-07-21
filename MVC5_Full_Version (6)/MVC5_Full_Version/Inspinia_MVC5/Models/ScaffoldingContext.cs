using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models
{
    public class ScaffoldingContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ScaffoldingContext() : base("name=ScaffoldingContext")
        {
        }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supporter>().HasOptional(s => s.Company_Id).WithRequired(c => c.Supporter);
        }*/

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Worker> Workers { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Geolocation> Geolocations { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Supporter> Supporters { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Application> Applications { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Application_Supporters> Application_Supporters { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Supporter_Roles> Supporter_Roles { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Utility> Utilities { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Content> Contents { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.ContentType> ContentTypes { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<Inspinia_MVC5.Models.QA> QAs { get; set; }
    
    }
}
