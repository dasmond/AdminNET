using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Application
{
    public interface IAuthService
    {
        Task<ClickWordCaptchaResult> GetCaptcha();

        Task<bool> GetCaptchaOpen();

        Task<LoginOutput> GetLoginUserAsync();

        string LoginAsync([FromBody] LoginInput input);

        Task LogoutAsync();

        Task<ClickWordCaptchaResult> VerificationCode(ClickWordCaptchaInput input);
    }
}