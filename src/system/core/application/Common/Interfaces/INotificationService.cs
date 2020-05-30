using System.Threading.Tasks;
using ManyToMany.System.Core.Application.Notifications;

namespace ManyToMany.System.Core.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}