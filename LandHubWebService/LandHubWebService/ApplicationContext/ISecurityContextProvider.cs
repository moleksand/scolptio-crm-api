using System.Collections.Generic;

namespace PropertyHatchWebApi.ApplicationContext
{

    public interface ISecurityContextProvider
    {
        SecurityContext GetSecurityContext(IEnumerable<System.Security.Claims.Claim> claims);
    }

}
