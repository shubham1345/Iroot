using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_CommunityInstitutionDetails : CommanProperties
    {
        public Tbl_CommunityInstitutionDetails()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        [Key]
        public int Id { get; set; }

        public string ActiveCkeck { get; set; }

        [StringLength(50)]
        public string MyId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Place { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }

        public string History { get; set; }
        public string Remark { get; set; }
        public string Remarks { get; set; }


        [StringLength(50)]
        public string Type { get; set; }
        public string Enterby { get; set; }
        public string EnterbyName { get; set; }
        public string EnterbyId { get; set; }
        [StringLength(50)]
        public string YearOfEstablacement { get; set; }

        public string Address { get; set; }


        [StringLength(100)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ParisId { get; set; }
        public string Activities { get; set; }
        public string Diocese { get; set; }

        [StringLength(100)]
        public string SocietyId { get; set; }
        public string Vission { get; set; }
        public string Mission { get; set; }

        [StringLength(100)]
        public string Telephone { get; set; }

        [StringLength(20)]
        public string InstitutionType { get; set; }


        [StringLength(320)]
        public string TypesOfReg { get; set; }

        [StringLength(100)]
        public string RegistrationNo { get; set; }
        [StringLength(50)]
        public string DiscCode { get; set; }
        [StringLength(50)]
        public string TypeCode { get; set; }
        [StringLength(50)]
        public string RegIdCode { get; set; }
        [StringLength(50)]
        public string BEORegCode { get; set; }
        [StringLength(50)]
        public string CertificationCode { get; set; }

        [StringLength(50)]
        public string OtherDoc { get; set; }

        [StringLength(50)]
        public string Doc1 { get; set; }

        [StringLength(50)]
        public string Doc2 { get; set; }

        [StringLength(50)]
#pragma warning disable CS0108 // 'Tbl_CommunityInstitutionDetails.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'Tbl_CommunityInstitutionDetails.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.

        [StringLength(50)]
        public string Tial { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string StartDate { get; set; }
        [StringLength(50)]
        public string CloseDate { get; set; }
        [StringLength(50)]
        public string SuspensionDate { get; set; }
        [StringLength(50)]
        public string RestartDate { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string EmailId { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(50)]
        public string Enitity { get; set; }
        [StringLength(50)]
        public string CommunityType { get; set; }
        [StringLength(50)]
        public string Continent { get; set; }
        [StringLength(50)]
        public string CommId { get; set; }
        [StringLength(150)]
        public string CongregationName { get; set; }
        [StringLength(150)]
        public string CommCode { get; set; }
        [StringLength(150)]
        public string DisSec { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}