

namespace Generalate.Models
{
    using Generalate.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class tbl_LandDetails : CommanProperties
    {
        [Key]
        public long Landid { get; set; }


        [StringLength(20)]
        public string RegDate { get; set; }

        [StringLength(20)]
        public string RegNo { get; set; }


        [StringLength(20)]
        public string SurveNo { get; set; }


        [StringLength(20)]
        public string DocCatogery { get; set; }

        [StringLength(35)]
        public string Discreption { get; set; }

        [StringLength(35)]
        public string File { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}
