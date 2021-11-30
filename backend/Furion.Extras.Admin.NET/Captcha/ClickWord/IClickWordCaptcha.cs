namespace Furion.Extras.Admin.NET
{
    public interface IClickWordCaptcha
    {
        ClickWordCaptchaResult CheckCode(ClickWordCaptchaInput input);

        ClickWordCaptchaResult CreateCaptchaImage(string code, int width, int height);

        string RandomCode(int number);
    }
}