
using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_provinceData : CommanProperties
    {
        public Tbl_provinceData()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        [Key]
        public int id { get; set; }
        public string ProvinceId { get; set; }
        public string MyId { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public string Member { get; set; }
#pragma warning disable CS0108 // 'Tbl_provinceData.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'Tbl_provinceData.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public string ActiveCkeck { get; set; }
        public string Name { get; set; }
        public string Mandate { get; set; }

    }
}