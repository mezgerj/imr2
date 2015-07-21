using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models
{
    public class QA
    {
        public virtual int? QAID { get; set; }
        public virtual String Title  { get; set; }
        public virtual String Subtitle { get; set; }
       
        
        public virtual String Question{ get; set; }

        public virtual String Answer { get; set; }
        public int? Type_Id { get; set; }

        public int? Application_Id { get; set; }

        public int? Geo_Id { get; set; }

        public int? DownloadTime { get; set; }


    }
}