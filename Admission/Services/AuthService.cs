using Admission.DB;
using Admission.Helper;
using Admission.Model.DomainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Admission.Services
{
    public class AuthService :IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly JWTHelper _jwthelper;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<JWTHelper> jwthelper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwthelper = jwthelper.Value;
        }


        public async Task<AuthModel> Register(Register register)
        {
            if (await _userManager.FindByEmailAsync(register.Email) != null)
            {
                return new AuthModel { Message = "Your Email is already Exists" };
            }
            if (await _userManager.FindByNameAsync(register.UserName) is not null)
            {
                return new AuthModel { Message = "Your User Name is alreadyExists" };
            }
            var user = new ApplicationUser { UserName = register.UserName, Email = register.Email };
            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                var Error = string.Empty;
                foreach (var error in result.Errors)
                {
                    Error += $"{error.Description}";
                }
                return new AuthModel { Message = Error };
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Trainee");
            }
            var token = await CreateToken(user);
            return new AuthModel
            {
                Email = user.Email,
                ExpiredAt = token.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Trainee" },
                Tokens = new JwtSecurityTokenHandler().WriteToken(token),
                Username = user.UserName,
                UserId=user.Id
            };

        }

        private async Task<JwtSecurityToken> CreateToken(ApplicationUser applicationUser)
        {
            var userClaim = await _userManager.GetClaimsAsync(applicationUser);
            var roleUser = await _userManager.GetRolesAsync(applicationUser);
            var role_claim = new List<Claim>();
            foreach (var role in roleUser)
            {
                role_claim.Add(new Claim("roleUser", role));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub , applicationUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email , applicationUser.Email),
            }.Union(userClaim)
            .Union(role_claim);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwthelper.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwthelper.Issuer,
                audience: _jwthelper.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(_jwthelper.DurationInDays));
            return jwtSecurityToken;
        }



        public async Task<AuthModel> Login(Login login)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
            {
                authModel.Message = "Invalid Email or Password";
                return authModel;
            }

            var jwtSecurityToken = await CreateToken(user);
            authModel.IsAuthenticated = true;
            authModel.Tokens = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email=user.Email;
            authModel.ExpiredAt = jwtSecurityToken.ValidTo;
            var roleList = await _userManager.GetRolesAsync(user);
            authModel.Roles=roleList.ToList();
            authModel.Username = user.UserName;
             authModel. UserId=user.Id;
            return authModel;
        }

        public async Task<string> AddRole(AddRole addRole)
        {
            var user = await _userManager.FindByIdAsync(addRole.UserId);
            if (user == null || !await _roleManager.RoleExistsAsync(addRole.RoleName))
            {
                return "Invalid UserId or UserRole";
            }
            if (await _userManager.IsInRoleAsync(user, addRole.RoleName))
            {
                return $"The User is already {addRole.RoleName}";
            }
            var result = await _userManager.AddToRoleAsync(user, addRole.RoleName);
            if (result.Succeeded)
            {
                return "The Role is Added";
            }
            else
            {
                return "Wrong Role";
            }
        }

    }
}

