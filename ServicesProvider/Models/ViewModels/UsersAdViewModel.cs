using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesProvider.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ServicesProvider.Models.ViewModels
{
    public class UsersAdViewModel
    {
        public SelectList SelectList { get; set; }

        public int Id { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(12, MinimumLength = 4)]
        public string Name { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 15)]
        public string ShortDesc { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(250, MinimumLength = 30)]
        public string LongDesc { set; get; }

        public string Img { set; get; }

        [Required]
        public ushort Price { set; get; }

        [Required]
        public int CategoryId { set; get; }

        public virtual Category Category { set; get; }

    }
}
