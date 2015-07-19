using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{

    public class Application_Supporters
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        [Key][Column(Order=0)]    
        public virtual int Application_Id { get; set; }

        [Key][Column(Order=1)]
        public virtual int Supporter_Id { get; set; }

    }
}