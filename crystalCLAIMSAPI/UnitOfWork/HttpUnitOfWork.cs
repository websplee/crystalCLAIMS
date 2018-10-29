using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using crystalCLAIMSAPI.Data;

namespace crystalCLAIMSAPI.UnitOfWork
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(CrystalCLAIMSDbContext context, IHttpContextAccessor httpAccessor) : base(context)
        {
            //context.CurrentUserId = httpAccessor.HttpContext.User.FindFirst(OpenIdConnectConstants.Claims.Subject)?.Value?.Trim();
        }
    }
}
