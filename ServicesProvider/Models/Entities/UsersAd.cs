using System;

namespace ServicesProvider.Models.Entities
{
    public class UsersAd
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string OwnerUsername { set; get; }
        public string ShortDesc { set; get; }
        public string LongDesc { set; get; }
        public string Img { set; get; }
        public ushort Price { set; get; }
        public Guid UserId { set; get; }
        public int CategoryId { set; get; }
        public virtual Category Category { set; get; }
    }
}
