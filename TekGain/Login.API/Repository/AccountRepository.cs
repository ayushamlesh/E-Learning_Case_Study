using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TekGain.DAL.Entities;

namespace Login.API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountRepository> _logger;

        public AccountRepository(
            ILogger<AccountRepository> logger,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        public async Task<IdentityResult> SignUp(SignUp signUpObj)
        {
            // Check if the implementation is correct for SignUp in the repository while valid input
            // You can add your implementation or checks here

            // Check if the email already exists
            var existingUser = await _userManager.FindByEmailAsync(signUpObj.Email);
            if (existingUser != null)
            {
                _logger.LogWarning($"{DateTime.Now} WAR: Sign up failed: Email '{signUpObj.Email}' already exists");
                return IdentityResult.Failed(new IdentityError { Description = "Email already exists" });
            }

            var user = new User
            {
                UserName = signUpObj.Email,
                Email = signUpObj.Email,
                FirstName = signUpObj.FirstName,
                LastName = signUpObj.LastName
            };
            var result = await _userManager.CreateAsync(user, signUpObj.Password);

            if (result.Succeeded)
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));

                await _userManager.AddToRoleAsync(user, "Admin");

                _logger.LogInformation($"{DateTime.Now} INFO: Registration completed for {signUpObj.Email}");
            }

            return result;
        }

        

        



         public async Task<string> SignIn(SignIn signInObj)
          {
              var user = await _userManager.FindByEmailAsync(signInObj.Email);
              if (user == null || !await _userManager.CheckPasswordAsync(user, signInObj.Password))
              {
                  _logger.LogWarning($"{DateTime.Now} WAR: Sign failed : {signInObj.Email}");
                  return "Incorrect Email/Password";
              }

              var roles = await _userManager.GetRolesAsync(user);
              var claims = new List<Claim>
              {
                  new Claim(ClaimTypes.Email, user.Email),


          };

              foreach (var role in roles)
              {
                  claims.Add(new Claim(ClaimTypes.Role, role));
              }

              var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
              var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
              var expires = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JWT:TokenExpirationDays"]));
              var token = new JwtSecurityToken(
                  _configuration["JWT:ValidIssuer"],
                  _configuration["JWT:ValidAudience"],
                  claims,
                  expires: expires,
                  signingCredentials: credentials
              );
              var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

              _logger.LogInformation($"{DateTime.Now} INFO: Sign success {signInObj.Email}");
              return tokenString;
          }

        /*
        public async Task<string> SignIn(SignIn signInObj)
        {
            var user = await _userManager.FindByEmailAsync(signInObj.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, signInObj.Password))
            {
                _logger.LogWarning($"{DateTime.Now} WAR: Sign failed : {signInObj.Email}");
                return "Incorrect Email/Password";
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Email, user.Email),
    };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenSecret = _configuration["JWT:Secret"];
            var tokenExpirationDays = Convert.ToInt32(_configuration["JWT:TokenExpirationDays"]);

            var token = GenerateJwtToken(_configuration["JWT:ValidIssuer"], _configuration["JWT:ValidAudience"], tokenSecret, tokenExpirationDays, claims);

            _logger.LogInformation($"{DateTime.Now} INFO: Sign success {signInObj.Email}");
            return token;
        }

        private string GenerateJwtToken(string issuer, string audience, string tokenSecret, int tokenExpirationDays, IEnumerable<Claim> claims)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(tokenExpirationDays);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
       */

    }
}