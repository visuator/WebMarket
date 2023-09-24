using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Infrastructure
{
    public class AuthenticatedActionFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Sid).Select(x => new { UserId = Guid.Parse(x.Value)}).SingleOrDefault();
            foreach(var i in context.ActionArguments.Values.OfType<IAuthenticated>().AsEnumerable())
            {
                if (user is null)
                {
                    context.Result = new UnauthorizedResult();
                    return Task.CompletedTask;
                }

                i.UserId = user.UserId;
            }

            return next.Invoke();
        }
    }
}
