using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Web.App.Observer.Events;
using Web.App.Observer.Observer;

namespace Web.App.Observer.EventHandlers
{
    public class CreatedUserWriteConsoleEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<CreatedUserWriteConsoleEventHandler> _logger;

        public CreatedUserWriteConsoleEventHandler(ILogger<CreatedUserWriteConsoleEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"user created : Id= {notification.AppUser.Id}");

            return Task.CompletedTask;
        }
    }
}
