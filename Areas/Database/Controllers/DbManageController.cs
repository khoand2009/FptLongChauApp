using FptLongChauApp.Data;
using FptLongChauApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;

namespace FptLongChauApp.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbManageController(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: DbManage
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SeedDataAsync()
        {
            //Create Roles
            var rolenames = typeof(RoleName).GetFields().ToList();
            foreach (var r in rolenames) 
            {
                var rolename = r.GetRawConstantValue() as string;
                var rfound = await _roleManager.FindByNameAsync(rolename);
                if (rfound == null) 
                {
                    await _roleManager.CreateAsync(new IdentityRole(rolename));
                }
            }

            var userAdmin = await _userManager.FindByEmailAsync("admin");
            if (userAdmin == null)
            {
                userAdmin = new AppUser()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(userAdmin, "admin123");
                await _userManager.AddToRoleAsync(userAdmin, RoleName.Administrator);

            }

            var userCustomer = await _userManager.FindByEmailAsync("customer");
            if (userCustomer == null)
            {
                userCustomer = new AppUser()
                {
                    UserName = "customer",
                    Email = "customer@gmail.com",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(userCustomer, "customer123");
                await _userManager.AddToRoleAsync(userCustomer, RoleName.Customer);

            }

            var userOwner = await _userManager.FindByEmailAsync("owner");
            if (userOwner == null)
            {
                userOwner = new AppUser()
                {
                    UserName = "owner",
                    Email = "owner@gmail.com",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(userOwner, "owner123");
                await _userManager.AddToRoleAsync(userOwner, RoleName.Owner);

            }
            
            return RedirectToAction("Index");
        }
    }
}
