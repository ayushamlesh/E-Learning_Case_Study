using Microsoft.AspNetCore.Identity;
using TekGain.DAL.Entities;

namespace Login.API.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignUp signUpObj);
        Task<String> SignIn(SignIn signInObj);
    }
}
