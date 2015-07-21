using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{

    public class Company
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        [Key]
        public int Company_Id { get; set; }

        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Display(Name = "Company Email")]
        public string Email { get; set; }

        [Display(Name = "Company Phone")]
        public string Phone { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Int32? PostalCode { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
                
        [Display(Name = "Admin")]
        public Int32? Admin_Id { get; set; }

        [Display(Name = "Company Url")]
        public string Company_Url { get; set; }


        //public virtual Supporter Supporter { get; set; }
    }
}