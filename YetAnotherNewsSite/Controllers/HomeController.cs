using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YetAnotherNewsSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace YetAnotherNewsSite.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index() => View(GetData(nameof(Index)));
        [Authorize(Roles = "Users")]
        public IActionResult OtherAction() => View("Index",
        GetData(nameof(OtherAction)));
        private Dictionary<string, object> GetData(string actionName) =>
new Dictionary<string, object>
{
    ["Action"] = actionName,
    ["User"] = HttpContext.User.Identity.Name,
    ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
    ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
    ["In Users Role"] = HttpContext.User.IsInRole("Users")
};
    }
}
