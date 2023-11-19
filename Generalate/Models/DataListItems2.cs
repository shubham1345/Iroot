using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class DataListItems2 : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(350)]
        public string DataListName { get; set; }

        [StringLength(350)]
        public string DataListItemName { get; set; }

        [StringLength(350)]
        public string Date { get; set; }

        [StringLength(150)]
        public string FromDate { get; set; }

        [StringLength(150)]
        public string ToDate { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [StringLength(350)]
        public string File { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}