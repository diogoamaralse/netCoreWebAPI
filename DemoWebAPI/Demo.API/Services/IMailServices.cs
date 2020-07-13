namespace Demo.API.Services
{
    public interface IMailServices
    {
        void Send(string subject, string message);
    }
}