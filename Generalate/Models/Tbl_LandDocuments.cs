using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_LandDocuments : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string MyId { get; set; }

        [StringLength(50)]
        public string ParisInstitutionName { get; set; }

        [StringLength(50)]
        public string DocumentCategory { get; set; }

        [StringLength(50)]
        public string SubCategory { get; set; }

        [StringLength(50)]
        public string Khasara { get; set; }

        [StringLength(50)]
        public string SurveyNo { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string RegistryDocumentFile { get; set; }

        [StringLength(100)]
        public string TaxbillFile { get; set; }

        [StringLength(100)]
        public string PavathiFile { get; set; }

        [StringLength(100)]
        public string MapFile { get; set; }
         
        [StringLength(100)]
        public string KhasaraFile { get; set; }

        [StringLength(50)]
#pragma warning disable CS0108 // 'Tbl_LandDocuments.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'Tbl_LandDocuments.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.

        [StringLength(50)]
        public string Year { get; set; }

        [StringLength(200)]
        public string Place { get; set; }
        [StringLength(100)]
        public string Tital { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}















