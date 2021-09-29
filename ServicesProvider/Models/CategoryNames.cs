using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesProvider.Models
{
    public class CategoryNames
    {
        public const string Programming = "Programming";
        public const string Design = "Design";

        public enum EnumOfCategoryNames
        {
            Programming = 1,
            Design,
        }
    }
}
