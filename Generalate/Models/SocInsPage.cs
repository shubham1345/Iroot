using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class SocInsPage : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Describtion { get; set; }
        public string Doc { get; set; }
      
        public string ProvinceName { get; set; }
    }
}