using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{

    public class Supporter_Roles
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
           
        [Key]
        public int Role_Id { get; set; }
        
        public string Name { get; set; }
        
    }
}