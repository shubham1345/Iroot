using Generalate.Models.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generalate.Models
{
    public class CounCircCommi : CommanProperties
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Describtion { get; set; }
        [StringLength(50)]
        public string Doc { get; set; }

        public string FileName { get; internal set; }
        public int EntryLifeId { get; internal set; }
        public string Type { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }

    }
}