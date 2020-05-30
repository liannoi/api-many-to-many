using System.Threading;
using System.Threading.Tasks;
using ManyToMany.System.Core.Application.Common.Interfaces;
using ManyToMany.System.Core.Application.Notifications;
using MediatR;

namespace ManyToMany.System.Core.Application.Storage.Books.Commands.Create
{
    public class BookCreated : INotification
    {
        public int BookId { get; set; }

        public class BookCreatedHandler : INotificationHandler<BookCreated>
        {
            private readonly INotificationService _notification;

            public BookCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(BookCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}