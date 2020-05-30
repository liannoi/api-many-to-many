using System.Threading;
using System.Threading.Tasks;
using ManyToMany.System.Core.Application.Common.Interfaces;
using ManyToMany.System.Core.Application.Notifications;
using MediatR;

namespace ManyToMany.System.Core.Application.Storage.Authors.Commands.Create
{
    public class AuthorCreated : INotification
    {
        public int AuthorId { get; set; }

        public class AuthorCreatedHandler : INotificationHandler<AuthorCreated>
        {
            private readonly INotificationService _notification;

            public AuthorCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(AuthorCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}