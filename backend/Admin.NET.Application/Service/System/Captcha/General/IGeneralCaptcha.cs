namespace Admin.NET.Application
{
    public interface IGeneralCaptcha
    {
        ClickWordCaptchaResult CheckCode(GeneralCaptchaInput input);

        ClickWordCaptchaResult CreateCaptchaImage(int length = 4);
    }
}