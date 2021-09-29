﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Data.DbObjects
{
    public class DbUsersAdManager
    {

        private readonly ApplicationDbContext _context;
        public DbUsersAdManager(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
        }
        public void AddUserAd(UserAdView userAdView, ApplicationUser user)
        {

            UsersAd UsersAd = new()
            {
                
                Name = userAdView.Name,
                LongDesc = userAdView.LongDesc,
                ShortDesc = userAdView.ShortDesc,
                Price = Convert.ToUInt16(userAdView.Price),
                CategoryId = userAdView.CategoryId,
                Img = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAcwAAAC4CAMAAABZwSzXAAADAFBMVEUAAAD+6cj+5cDliD//wUX/sFH///H+qVP/wUf/qUz/u0H/p0n9m0b/rjX/tTuwWDKwWTL//dn/wEWxWDK9XzP/qC6uWDL/v1GwWDK9XTX/oiexWjOpVDChUC2hWDuZTCz/7M3IayX1gjj4hTjXeSbxl1L+jz3/lD79iTrzjkTehjPslDf/k0X5iDv3gDWMRzGRRSX6hTfyfTWIQia8UyfHViD+dy+uTiOAQCzRWyLbXiP9oVn/olz+jTXyaSn/oVR0PCj/mh/+m1H+bSLkeTbwdjLVaCf/mUrkWyDujSHrci/rYST/lzS+Xx//gSeVTjj/nEH/pXf/vJv/sovmayzhZSb3eyf/iC60Vxz+m0z5gyvdVB3ydSD/7c7/rU3/68n/5rv20Jv/1Ir/2ZP/6sf/s2GbRB3/3J//25b+1qL+zpf/14//1In/15n/rlqBPCFzMhr/6sb/68j/68n/4J7/6sbwfCT/pU3+xor/0IT/0Y7+jRr/uGajSB3/zX7/w4DSTBn/yHnubR3/oEr/xHLJQxP92Kz+vm30fy3ailH/fR//7c3/1IG7u76oyuG3m5H9cg6UPBT/v2qq3fn/qFX+tljrVgumvc+8il7cRgtdMiL/3aj/xWv/wGOZnqm/Nwv/u117rdCSs8uBnraWkZe6ShnuZguqTRj0qlz/57r7t3imhn7kj0C7cEqoblP/zXj2bQz7Xgz3mUrWYDqtORb/ynLoq3H3rVD0pUf/6sb/7Mz/68v/7c7/7Mz/6cP/6cX/7s//6sb/6cT/68f/7c3/7tH/68f/78//8tf/79X/7tD/6ML/6MH/7Mr/7dD/79P/7Mr/573/6sj/57//7c7/9tb/6cL/6cb/6cT/6cfinmGFMw7unED8smr/5rz/57//0X30xZD/8tLuuH//+eDQezn4z5393K//4LL/577uo03/xXv+s1D/+uXnmlD/5ryoIwT/5Ln/eBb/5Ij+rV+9g2Des47/7MX5wYmKbkbOl3IEBQhVSTb///7i4+MuJBuN0484AAAA/XRSTlMABgwlx5YBt/53/0Bc//9JewLpsP//nv/B5//////v/xT/u5f/3v////z//////////////////////+n///////////7///////////////////////////H///8f/zler+mTR///1/+4wP//y////3xxMv9P///M/9j/////2//////////w////Kv///////////////////8H//////////////////9L///7q/////////////z9WZY6DiaWXspumpqGgnZ+mpqaUoqampqGlqqWYo6ampv///+Kmpv////+a//+vuKT+6f+R/7H/pv//8dnApMP3z//8JReY6AAAZi9JREFUeAHs1wGOmzAQheEBIHkZgiEDULa2Q3v/S9a4qypb7QEget8Vfj2PLEREREREREREREREREREdDhFKW+Cqrq5yHugK67yHugG1O+yTLZURSt0fpc70DnUpdCZ9MPju12apZic5qkU4zSN8r8WyeyARs6Dlinp5avKkMz641TvLK1T8iFflDVUoT8VZnc5DRq9TzUHedUA2qWYDsBNToNWv9dc5UVrABx0VsCaSujoimFd+xwze0lW1EicczmmHX+a1Pu/p3INKWXwg/xzR76YXTdjdy2EDq6akkFkjCEEH56Pl2GqKuDmGbu6FTpBTO9LWWMMu14+3cxUkXwu05qH0LFVH6mlH2WJW6oZwyIiw1LJL4M6ReLmvFCzSujgVr8r+piEuD0fMoTwvLQAnFPdl5kvJ38np4m59Fvctpjm2fchhG1pDHCdquZnVmdndV0KHdvgs3Hb8jTj+kwx428zQDsHRdflYVptd6FjaP+wa17rqRtRFLatuAmkVKWMTQjIFoOPNDDCR8ZNBIjcu8Xp7/8cWWuk9HIHX4p+S0O5/b327D2i7df/LFpWIRMVFhifcNnYQWm14RAvnseImulkqeKfwW7Qkd3anx2xFy4btMm1wWVvo5RpQ2bhElGtWqB/BivdQMqgU//li7ZfHhtA5bYxWIaTWl8UMj0XMgVW2vyntEAVVtjphND5s00/UsV7qwhmUWd7Pa79Lc+0sq5wcGMB5uDgnzFqVvhBJ5BaRmWlrcdax+b9yjeUCaBysL1vZLZcuHQdx4NMz7NLmdUPDv4p1IIOghnobpHHtlKlWdZZ2ER97Q1eJsnBsNnv70GlS5mosI7j/mxz9W/qeK2+sqDZpcKCSSklHNKmFcexDqLYtDTfbhcNUO8wSZKjQb/XfGEzl9BJmXRJ2AR99xf/KfXV45OT4+PVSudCqGkZnEY6kiqGTT8mSrVN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",
                UserId = user.Id,
                OwnerUsername = user.UserName,
                Category = FindCategoryByCategoryId(userAdView.CategoryId),
            };

            _context.AddAsync(UsersAd);
            _context.SaveChanges();
        }

        public Category FindCategoryByCategoryId(int CategoryId)
        {
            return _context.Category.FirstAsync(x => x.Id == CategoryId).GetAwaiter()
                .GetResult(); ;
        }
    }
}