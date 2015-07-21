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
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Content> Contents { get; set; }
        public IEnumerable<Utility> Utilities { get; set; }
        public IEnumerable<Company> Companies { get; set; }

        private ScaffoldingContext db = new ScaffoldingContext();


        public void PopulateModel()
        {
            Applications = db.Applications.ToList();
            Supporters = db.Supporters.ToList();
            Geolocations = db.Geolocations.ToList();
            Contents = db.Contents.ToList();
            Utilities = db.Utilities.ToList();
            Companies = db.Companies.ToList();
            Events = db.Events.ToList();
        }

    }
}