using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesProvider.Models.Entities
{
    public class UsersAd
    {
        [NotMapped]
        private DateTime _creatinDate;
        public int Id { set; get; }
        public string Name { set; get; }
        public string OwnerUsername { set; get; }
        public string ShortDesc { set; get; }
        public string LongDesc { set; get; }
        public ushort Price { set; get; }
        public int CategoryId { set; get; }
        public virtual Category Category { set; get; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string CreatinDate
        {
            set { _creatinDate = Convert.ToDateTime(value); }
            get { return string.Format("{0:g}", _creatinDate); }
        }
    }
}
