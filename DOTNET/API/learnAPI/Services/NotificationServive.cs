namespace learnAPI.Services
{
    public interface INotificationService { string SendMessage(); }

    public class SmsNotificationService : INotificationService
    {
        public string SendMessage() { return "SMS Sent to User"; }
    }
    public class EmailNotificationService : INotificationService
    {
        public string SendMessage() { return "Email Sent to User"; }
    }
}