using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models
{
    public partial class NavigationView
    {
        public IEnumerable<Application> Applications { get; set; }
        public IEnumerable<Supporter> Supporters { get; set; }
        public IEnumerable<Geolocation> Geolocations { get; set; }

        private ScaffoldingContext db = new ScaffoldingContext();


        public void PopulateModel()
        {
            Applications = db.Applications.ToList();
            Supporters = db.Supporters.ToList();
            Geolocations = db.Geolocations.ToList();
        }

    }
}