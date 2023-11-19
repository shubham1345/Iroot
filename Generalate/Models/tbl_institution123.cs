
namespace Generalate.Models
{
    using Generalate.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class tbl_institution123 : CommanProperties
    {
        [Key]
        public long InstitutionId { get; set; }



        [StringLength(15)]
        public string MemberID { get; set; }

        [StringLength(20)]
        public string FromDate { get; set; }

        [StringLength(20)]
        public string Closingdate { get; set; }


        [StringLength(20)]
        public string NameOfInstitution { get; set; }


        [StringLength(20)]
        public string TypeOfInstitution { get; set; }

        [StringLength(35)]
        public string NameOfDiocese { get; set; }

        [StringLength(35)]
        public string OwenedBy { get; set; }

        [StringLength(35)]
        public string MaintainedBy { get; set; }

        [StringLength(100)]
        public string Address { get; set; }


        [StringLength(100)]
        public string Telephone { get; set; }


        [StringLength(35)]
        public string EmailID { get; set; }

        [StringLength(35)]
        public string WebSite { get; set; }

        [StringLength(100)]
        public string spare1 { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
        [StringLength(100)]
        public string Spare2 { get; set; }
    }
}

