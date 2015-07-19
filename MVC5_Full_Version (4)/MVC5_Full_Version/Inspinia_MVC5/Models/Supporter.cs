using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{

    public class Supporter
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        [Key]
        public int Supporter_Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Company")]
        public Nullable<int> Company_Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Int32? PostalCode { get; set; }
        public string Password { get; set; }
        public bool FirstTime { get; set; }

        [Display(Name = "Role")]
        public Int32? Role_Id { get; set; }
        public bool RememberMe { get; set; }

        public virtual Supporter_Roles Supporter_Roles { get; set; }
        public virtual Company Company { get; set; }

        //Finds all the applications that are associated with a user.
        ScaffoldingContext db = new ScaffoldingContext();
        public IQueryable<Application> findApplications()
        {
            return from user in db.Supporters 
                   join mid in db.Application_Supporters
                      on user.Supporter_Id equals mid.Supporter_Id 
                   join app in db.Applications
                       on mid.Application_Id equals app.Application_Id
                   where user.Supporter_Id.Equals(Supporter_Id)
                   select app;
        }
    }
}