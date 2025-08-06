using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserAuthtication.Areas.Identity.Data;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UserAuthtication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }   

        public async Task<IActionResult> Index(string role = null)
        {
            var users = _userManager.Users.ToList();
            var userRoles = new Dictionary<string, IList<string>>();
            foreach (var user in users)
            {
                userRoles[user.Id] = await _userManager.GetRolesAsync(user);
            }
            var roles = new List<string> { "Admin", "User" };
            if (role == "Admin")
            {
                users = users.Where(u => userRoles[u.Id].Contains("Admin")).ToList();
            }
            else if (role == "User")
            {
                // Show all users who are NOT admins (including those with no roles)
                users = users.Where(u => !userRoles[u.Id].Contains("Admin")).ToList();
            }
            // else: show all users (including admins and users with no roles)
            ViewBag.Roles = roles;
            ViewBag.SelectedRole = role;
            ViewBag.UserRoles = userRoles;
            return View(users);
        }
    }
} 