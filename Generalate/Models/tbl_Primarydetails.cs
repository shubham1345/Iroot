using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    
    public partial class tbl_Primarydetails : CommanProperties
    {
        [Key]
        public int Primaryid { get; set; }
        [StringLength(50)]
        public string MemberId { get; set; }

        [StringLength(50)]
        public string Knowname { get; set; }

        [StringLength(50)]
        public string Baptismialname { get; set; }

        [StringLength(50)]
        public string DOB { get; set; }
        [StringLength(50)]
        public string DOB1 { get; set; }
        [StringLength(50)]
        public string Feastday { get; set; }
        [StringLength(50)]
        public string Bloodgroup { get; set; }
        [StringLength(50)]
        public string emailid { get; set; }
       
        [StringLength(50)]
        public string mobilenumber { get; set; }
        [StringLength(50)]
        public string placeofbirth { get; set; }
        [StringLength(50)]
        public string noofbrother { get; set; }
        [StringLength(50)]
        public string noofsisters { get; set; }
        [StringLength(50)]
        public string placeinfamily { get; set; }
        [StringLength(50)]

        public string homediocese { get; set; }
        [StringLength(50)]
        public string homeparish { get; set; }
        [StringLength(50)]

        public string house { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string district { get; set; }

        [StringLength(50)]
        public string Congregation { get; set; }
        [DisplayName("state")]
        public string state { get; set; }
        [StringLength(50)]
        public string pin { get; set; }
        [StringLength(50)]
        public string adhar { get; set; }
        [StringLength(50)]
        public string pan { get; set; }
        [StringLength(50)]
        public string passport { get; set; }
        [StringLength(50)]
        public string DrivingLicense { get; set; }
        [StringLength(50)]
        public string nameonadhar { get; set; }
        [StringLength(50)]
        public string nameonpan { get; set; }  
        [StringLength(50)]
        public string nameonpassport { get; set; }
        public string File1 { get; set; }
        public string File2 { get; set; }
        public string File3 { get; set; }
        [StringLength(50)]
        public string Ordination { get; set; }
        public string UploadPhoto { get; set; }
        [StringLength(50)]
        public string country { get; set; }
        public string Continent { get; set; }
        public string LangSpocken { get; set; }
        public string Will { get; set; }
        [StringLength(50)]
        public string mothertounge { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; }
        ////////////
        public string OtherName { get; set; }
        public string FathersBaptismialName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MothersBaptismialName { get; set; }
        public string Paris { get; set; }
        public string PlaceInTheFamily { get; set; }
        public string Diocese { get; set; }
        public string HouseNo { get; set; }
        public string HouseName { get; set; }
        public string Distict { get; set; }
        public string Pincode { get; set; }
        public string SurName { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public string Address { get; set; }
        [StringLength(200)]
        public string NameInTheCertificate { get; set; }
        [StringLength(50)]
        public string DOBInTheCertificate { get; set; }
        public string ReligiousTitle { get; set; }
        public object Id { get; internal set; }
        public bool Name { get; internal set; }
        public string Telephone { get; set; }
        public string Remarks { get; set; }
        
    }
}