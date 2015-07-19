using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{

    public class Continent
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        public int ContinentID { get; set; }
        public string Name { get; set; }



       

    }
}