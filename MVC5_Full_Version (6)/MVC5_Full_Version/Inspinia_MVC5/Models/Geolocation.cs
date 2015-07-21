using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{

    public class Geolocation
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        public int GeolocationID { get; set; }
        public string Name { get; set; }

        public System.Double? Latitude { get; set; }
        public System.Double? Longitude { get; set; }
        public System.Double? Altitude { get; set; }
        public string Description { get; set; }
        public Int32? Application_Id { get; set; }
        public Int32? Parent_Geo_Id { get; set; }
        public System.Double? Range { get; set; }
        public int DownloadTime { get; set; }
        public Int32? ContinentID { get; set; }

        public Int32? CityID { get; set; }

        public Int32? CountryID { get; set; }
        public Int32? StateID { get; set; }



       

    }
}