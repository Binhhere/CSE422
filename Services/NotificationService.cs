namespace LibraryManagementSystem.Services;

public class NotificationService
{
    public virtual void SendNotification(string message)
    {
        Console.WriteLine($"[Notify] {message}");
    }

    public void SendNotification(string message, string recipient)
    {
        Console.WriteLine($"[Notify] To {recipient}: {message}");
    }

    public void SendNotification(string message, List<string> recipients)
    {
        foreach (var recipient in recipients)
        {
            SendNotification(message, recipient);
        }
    }
}
