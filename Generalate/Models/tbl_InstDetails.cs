using System;
using System.Web;

namespace Generalate.Models
{
    using Generalate.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_InstDetails : CommanProperties
    {
        [Key]
        public long Instid { get; set; }


        [StringLength(20)]
        public string Date { get; set; }

        [StringLength(20)]
        public string Tital { get; set; }


        [StringLength(20)]
        public string Catogory { get; set; }


        [StringLength(20)]
        public string Remark { get; set; }

        [StringLength(35)]
        public string File { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}
