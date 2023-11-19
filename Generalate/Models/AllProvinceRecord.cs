using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class AllProvinceRecord : CommanProperties
    {
        [Key]
        public int PRId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public string Totalproffess { get; set; }
        public string GrandtotalProfNovStart { get; set; }
        public string TPorFP { get; set; }
        public string PerProf { get; set; }
        public string GrandtotalProfLast { get; set; }
        public string FirststNovices { get; set; }
        public string SecondNovices { get; set; }
        public string GrandtotalProfNovLast { get; set; }
        public string NovDepart { get; set; }

        public string VTDepart { get; set; }
        public string VPDepart { get; set; }
        public string Death { get; set; }
        public string Transfer1 { get; set; }
        public string Transfer2 { get; set; }

        public string Total { get; set; }
        public string Total1 { get; set; }
        public string Total2 { get; set; }
        public string Total3 { get; set; }
        public string Total4 { get; set; }
        public string Total5 { get; set; }
        public string Total6 { get; set; }
        public string Total7 { get; set; }
        public string Total8 { get; set; }
        public string Total9 { get; set; }
        public string Total10 { get; set; }
        public string Total11 { get; set; }
        public string Total12 { get; set; }
        public string Total13 { get; set; }

        public string Extratbl { get; set; }
        public string Extratbl1 { get; set; }


    }
}