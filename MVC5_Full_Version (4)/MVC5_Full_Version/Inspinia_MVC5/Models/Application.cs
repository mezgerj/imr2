using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{

    public class Application
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        
        [Key]
        public int Application_Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Company")]
        public Int32? Company_Id { get; set; }

        [Display(Name = "Application Token")]
        public string ApplicationToken { get; set; }

        public virtual Company Company { get; set; }

        //Finds all the users that are associated with an application.
       ScaffoldingContext db = new ScaffoldingContext();
       public IQueryable<Supporter> findSupporters()
       {
           return from app in db.Applications
                  join mid in db.Application_Supporters
                     on app.Application_Id equals mid.Application_Id
                  join user in db.Supporters
                      on mid.Supporter_Id equals user.Supporter_Id
                  where app.Application_Id.Equals(Application_Id)
                  select user;
       }
       
    }
}