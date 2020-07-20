using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;

namespace WpfIdentity.IdentityServer
{
    public class CustomIdentityResourcesProfile : IdentityResources.Profile
    {
        public CustomIdentityResourcesProfile()
        {
            this.UserClaims.Add(JwtClaimTypes.Role);
        }
    }
}
