using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tbl_Congregation : CommanProperties
    {
        public tbl_Congregation()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/mm/yyyy");
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string CongreId { get; set; }
        public string CongregationName { get; set; }
        public string Establishment { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
#pragma warning disable CS0108 // 'tbl_Congregation.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'tbl_Congregation.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        
        public string History { get; set; }
        public string Country { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public string File { get; set; }
        public string Vission { get; set; }
        public string Mission { get; set; }
        public string Activities { get; set; }
        public string Diocese { get; set; }
        public string FamilyBelongsTo { get; set; }
        public string NameofFounder { get; set; }
        public string NameofCoFounder { get; set; }
        public string CongregationMotto { get; set; }
        public string CongregationLogo { get; set; }
        public string CongregationCountriesofMission { get; set; }
        public string FoundationDate { get; set; }
        public string Foundationday { get; set; }
        public string DiocesanDecreeDate { get; set; }
        public string PontificalDecreeDate { get; set; }
        public string GouvernementalDecreeDate { get; set; }
        public string DepCIVCSVA { get; set; }
        public string Continent { get; set; }
        public string Remarks { get; set; }
    }
}