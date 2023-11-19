using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tbl_unknow : CommanProperties
    {
        [Key]
        public int memid { get; set; }
        public string Knowname { get; set; }
        public string Baptismialname { get; set; }
        public string DOB { get; set; }
        public string DOB1 { get; set; }
        public string Feastday { get; set; }
        public string Bloodgroup { get; set; }
        public string emailid { get; set; }
        public string mobilenumber { get; set; }
        public string whatsappnumber { get; set; }
        public string facebookid { get; set; }
        public string twitterid { get; set; }
        public string blog { get; set; }
        public string house { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string pin { get; set; }
        public string adhar { get; set; }
        public string pan { get; set; }
        public string nameonadhar { get; set; }
        public string File1 { get; set; }
        public string File2 { get; set; }
        public string nameonpan { get; set; }
        
        
    }
}
