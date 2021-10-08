namespace Mahwous.Core.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(string title, string content);
    }
}
