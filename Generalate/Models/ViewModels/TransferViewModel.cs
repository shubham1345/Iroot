
using System.Collections.Generic;

namespace Generalate.Models.ViewModels
{
    public class TransferViewModel
    {
        public string TransferDate { get; set; }
        public string OldProvinceName { get; set; }
        public string OldProvinceId { get; set; }
        public List<string> BrothersMemberID { get; set; }
        public string NewProvinceName { get; set; }
        public string NewProvinceId { get; set; }
    }
}