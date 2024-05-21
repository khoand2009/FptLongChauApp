using System.Collections.Generic;
using System.ComponentModel;
using FptLongChauApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FptLongChauApp.Areas.Identity.Models.User
{
  public class AddUserRoleModel
  {
    public AppUser user { get; set; }

    [DisplayName("Các role gán cho user")]
    public string[] RoleNames { get; set; }

    public List<IdentityRoleClaim<string>> claimsInRole { get; set; }
    public List<IdentityUserClaim<string>> claimsInUserClaim { get; set; }

  }
}