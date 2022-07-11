﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NetCoreApp.Data.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreApp.Helpers
{
    public class CustomClaimsPrincipalFactory: UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        private readonly UserManager<AppUser> _userManger;

        public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, 
            IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _userManger = userManager;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var roles = await _userManger.GetRolesAsync(user);
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim("Email",user.Email),
                new Claim("FullName",user.FullName),
                new Claim("Avatar",user.Avatar??"/admin/assets/img/user1.png"),
                new Claim("Roles",string.Join(";",roles)),
                new Claim("UserId",user.Id.ToString())
            });
            return principal;
        }
    }
}
