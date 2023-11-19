using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tbl_Archive : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MemberId { get; set; }
        public string ArchiveNo { get; set; }
        public string Date { get; set; }
        public string FileNo { get; set; }
        public string ProvinceName { get; set; }
        public string Archivecheck { get; set; }
        public string Description { get; set; }
    }
}