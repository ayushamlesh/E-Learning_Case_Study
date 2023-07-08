using Login.API.Repository;
using Microsoft.AspNetCore.Mvc;
using TekGain.DAL.Entities;

namespace Login.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {

        // Implement the Services here
        
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUpObj)
        {
            try
            {
                await _accountRepository.SignUp(signUpObj);
                return Ok("User Account created");
            }
            catch (Exception)
            {
                return BadRequest("Failed to create account");
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignIn signInObj)
        {
            try
            {
                string token;
                var result = await _accountRepository.SignIn(signInObj);
                if (result == "Failed")
                {
                    return BadRequest("Failed to login");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Failed to login");
            }
        }
    }
}
