using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{

    public class Utility
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        [Key]
        public int Utility_Id { get; set; }

        //[DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Item { get; set; }

        public string Method { get; set; }

    }
}