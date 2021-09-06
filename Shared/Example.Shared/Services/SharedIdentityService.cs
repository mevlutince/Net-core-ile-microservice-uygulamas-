using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        // jwt üzerinden gelen tokkendan kullanıcıyı alacaz yani "sub"

        private IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;

    }
}
