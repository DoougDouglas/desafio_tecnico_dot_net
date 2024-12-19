namespace EclipseWorks.DesafioTecnico.Services
{
    public interface IDomainNotificationAppService
    {
        bool HasNotifications { get; }
        void Add(string notification);
        void Add(string[] notifications);
        IReadOnlyCollection<string> GetNotifications();
    }

    public sealed class DomainNotificationAppService : IDomainNotificationAppService
    {
        private readonly HashSet<string> _notifications;
        public bool HasNotifications => _notifications.Any();

        public DomainNotificationAppService()
        {
            _notifications = [];
        }

        public void Add(string notification)
        {
            _notifications.Add(notification);
        }

        public void Add(string[] notifications)
        {
            foreach (var notification in notifications)
            {
                _notifications.Add(notification);
            }
        }

        public IReadOnlyCollection<string> GetNotifications() => _notifications.ToArray();
    }
}