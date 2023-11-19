using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class ExcelSheetData : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string DataType { get; set; }
        public string FileUpload { get; set; }
        public string Workbook { get; set; }
        public string AccessionNo { get; set; }
        public string BarcodeId { get; set; }
        public string BarcodeImage { get; set; }
        public string Title { get; set; }
    }
}