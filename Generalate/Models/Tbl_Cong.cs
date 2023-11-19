using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_Cong : CommanProperties
    {
        public Tbl_Cong()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string CommId { get; set; }
        public string CongregationName { get; set; }
        public string CommCode { get; set; }
        public string GenCode { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string EmailId { get; set; }
        public string DisSec { get; set; }
        public string ActiveCkeck { get; set; }
#pragma warning disable CS0108 // 'Tbl_Cong.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'Tbl_Cong.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string Enterby { get; set; }
        public string EnterbyName { get; set; }
        public string EnterbyId { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public string File { get; set; }
        public string Vission { get; set; }
        public string Mission { get; set; }
        public string Activities { get; set; }
        public string Diocese { get; set; }
        public string PostalCode { get; set; }
        public string Enitity { get; set; }
        public string Continent { get; set; }
        public string CommunityType { get; set; }
        public int Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SuspensionDate { get; set; }
        public string RestartDate { get; set; }
        public string Remark { get; set; }
        public string History { get; set; }
        public string Remarks { get; set; }
        public string IsStatisticActive { get; set; }
    }
}