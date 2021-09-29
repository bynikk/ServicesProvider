using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesProvider.Models.Entities
{
    public class UserAdView
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
