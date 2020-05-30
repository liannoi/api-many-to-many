using System.Threading.Tasks;
using ManyToMany.System.Core.Application.Common.Interfaces;
using ManyToMany.System.Core.Application.Notifications;

namespace ManyToMany.System.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}