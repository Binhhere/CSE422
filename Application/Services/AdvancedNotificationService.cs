using Application.Services;

namespace Application.Services;

public class AdvancedNotificationService : NotificationService
{
    public override void SendNotification(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] [Notify] {message}");
    }
}
