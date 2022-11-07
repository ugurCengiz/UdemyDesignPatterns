using System.Threading;
using System.Threading.Tasks;
using BaseProject.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Web.App.Observer.Events;
using Web.App.Observer.Models;

namespace Web.App.Observer.EventHandlers
{
    public class CreateDiscountEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly AppIdentityDbContext _context;
        private readonly ILogger<CreateDiscountEventHandler> _logger;

        public CreateDiscountEventHandler(AppIdentityDbContext context, ILogger<CreateDiscountEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            await _context.Discounts.AddAsync(new Models.Discount { Rate = 10, UserId = notification.AppUser.Id });
            await _context.SaveChangesAsync();
            _logger.LogInformation("Discount created");
        }
    }
}
