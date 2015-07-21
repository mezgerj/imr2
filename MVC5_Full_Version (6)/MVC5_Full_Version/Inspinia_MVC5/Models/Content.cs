using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{

    public class Content
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        [Key]
        public int Content_Id { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Application")]
        public int Application_Id { get; set; }

        [Display(Name = "Content Type")]
        public int ContentType_Id { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }

        [Display(Name = "Download Time")]
        public int DownloadTime { get; set; }

        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "Not a valid positive integer")]
        [Display(Name = "Sequence")]
        public Nullable<int> Seq { get; set; }

        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "Not a valid positive integer")]
        [Display(Name = "Order")]
        public Nullable<int> Place { get; set; }

        public virtual ContentType ContentType { get; set; }
        public virtual Application Application { get; set; }

    }
}