using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tbl_Province : CommanProperties
    {
        public tbl_Province()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/mm/yyyy");
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string MyId { get; set; }
        public string ProvinceName { get; set; }
        public string Place { get; set; }
        public string Place1 { get; set; }
        public string ActiveCkeck { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Country { get; set; }
        public string EmailId { get; set; }
        public string History { get; set; }
#pragma warning disable CS0108 // 'tbl_Province.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }      
#pragma warning restore CS0108 // 'tbl_Province.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string DisSec { get; set; }
        public string File { get; set; }
        public string Vission { get; set; }
        public string Mission { get; set; }
        public string Activities { get; set; }
        public string Diocese { get; set; }
        public string ProvinceMotto { get; set; }
        public string ProvinceLogo { get; set; }
        public string ProvinceCountriesofMission { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SuspensionDate { get; set; }
        public string RestartDate { get; set; }
        public string NameofFounders { get; set; }
        public string NameofFounder { get; set; }
        public string Continent { get; set; }
    }
}