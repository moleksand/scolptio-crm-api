using Microsoft.AspNetCore.Mvc;

using PropertyHatchWebApi.ApplicationContext;

using System;

namespace PropertyHatchWebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public SecurityContext SecurityContext
        {
            get
            {
                return (SecurityContext)Activator.CreateInstance(typeof(SecurityContext), HttpContext.User.Claims);
            }
        }

    }
}
