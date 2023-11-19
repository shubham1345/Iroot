using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Emaildata
    {
    public int Id { get; set; }
      [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter PersonalDetails.")]
    public string PersonalDetails { get; set; }
      [Required(AllowEmptyStrings = true, ErrorMessage = "Please enter CCAddress.")]
      public string CCAddress { get; set; }
      [Required(AllowEmptyStrings = true, ErrorMessage = "Please enter BCCAddress.")]
      public string BCCAddress { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Subject")]
    public string Subject { get; set; }
       [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Body.")]
    public string Body { get; set; }
    [Required(ErrorMessage = "Please select file.")]
    [Display(Name = "Browse File")]
    public HttpPostedFileBase[] files { get; set; }  


    }

}