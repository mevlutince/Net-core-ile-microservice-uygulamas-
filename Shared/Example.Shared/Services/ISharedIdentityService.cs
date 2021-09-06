using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Shared.Services
{
   public interface ISharedIdentityService
    {
        public string GetUserId { get; }  
    }
}
