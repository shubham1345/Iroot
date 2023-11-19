using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class MultiLanguage : CommanProperties
    {
        public MultiLanguage()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
            Language = "EN";
            Language2 = "FN";
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        public string ControlId { get; set; }
        public string ControlText { get; set; }
        public string Language { get; set; }
        public string FranchText { get; set; }
        public string Language2 { get; set; }
#pragma warning disable CS0108 // 'MultiLanguage.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'MultiLanguage.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string SpanishText { get; set; }
        public string Language3 { get; set; }
        public string ItalyText { get; set; }
        public string Language4 { get; set; }
        public string GermanText { get; set; }
        public string Language5 { get; set; }
    }
}