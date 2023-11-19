using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Societys : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string SocId { get; set; }
        [StringLength(50)]
        public string MemberId { get; set; }
        public string ActiveCkeck { get; set; }
        [StringLength(100)]
        public string PanNumber { get; set; }
        [StringLength(200)]
        public string NameOfTheSocity { get; set; }
        public string Enterby { get; set; }
        public string EnterbyName { get; set; }
        public string EnterbyId { get; set; }
        [StringLength(50)]
        public string FCRANumber { get; set; }
        [StringLength(50)]
        public string Date { get; set; }
        [StringLength(50)]
        public string Number12A { get; set; }
        [StringLength(50)]
        public string Number12AA { get; set; }
        [StringLength(50)]
        public string RegistrationNumber { get; set; }
        [StringLength(50)]
        public string Number80G { get; set; }
        [StringLength(50)]
        public string Address{ get; set; }
        [StringLength(50)]
        public string Telno { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Website { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        [StringLength(550)]
        public string TypesOfReg { get; set; }
        public string File { get; set; }
        public string Vission { get; set; }
        public string Mission { get; set; }
        public string Activities { get; set; }
        public string Diocese { get; set; }
        public string DisSec { get; set; }
    }
}
