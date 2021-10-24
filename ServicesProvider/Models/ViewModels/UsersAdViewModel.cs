using ServicesProvider.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ServicesProvider.Models.ViewModels
{
    public class UsersAdViewModel
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string ShortDesc { set; get; }
        [Required]
        public string LongDesc { set; get; }
        public string Img { set; get; }
        [Required]
        public ushort Price { set; get; }
        [Required]
        public int CategoryId { set; get; }
        public virtual Category Category { set; get; }
    }
}
