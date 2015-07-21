using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{
    public class Event
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        
        [Key]
        public int ID { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int Application_Id { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

    }
}