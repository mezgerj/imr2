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
        public Int32? Company_Id { get; set; }
        public string ApplicationToken { get; set; }

    }
}