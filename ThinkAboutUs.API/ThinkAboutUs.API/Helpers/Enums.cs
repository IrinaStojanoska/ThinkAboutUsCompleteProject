using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkAboutUs.API.Helpers
{
    public enum Status
    {
        Homeless = 0,
        Lost = 1,
        PendingAdoption = 2,
        PendingFound = 3,
        Adopted = 4,
        Found = 5,
    }

    public enum Gender
    {
        Male = 0,
        Female = 1,
    }
}
