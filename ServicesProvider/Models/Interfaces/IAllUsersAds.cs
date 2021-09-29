using System;
using System.Collections.Generic;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Models.Interfaces
{
    public interface IAllUsersAds
    {
        IEnumerable<UsersAd> UsersAds { get; }

        UsersAd GetUserAd(int userAdId);

    }
}
