using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesProvider.Models.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesProvider.Models.ViewModels
{
    public class UsersAdViewModel
    {
        

        public UsersAdViewModel()
        {

        }
        public UsersAdViewModel(UsersAd userAdModel)
        {
            Id = userAdModel.Id;
            Name = userAdModel.Name;
            ShortDesc = userAdModel.ShortDesc;
            LongDesc = userAdModel.LongDesc;
            Price = userAdModel.Price;
            CategoryId = userAdModel.CategoryId;
            Category = userAdModel.Category;
            ImageName = userAdModel.ImageName;
            CreatinDate = userAdModel.CreatinDate;
        }
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

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload file:")]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        private DateTime _creatinDate;
        public string CreatinDate
        {
            set { _creatinDate = Convert.ToDateTime(value); }
            get { return string.Format("{0:g}", _creatinDate); }
        }

    }
}
