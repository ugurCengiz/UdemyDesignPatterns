using BaseProject.Models;
using MediatR;

namespace Web.App.Observer.Events
{
    public class UserCreatedEvent:INotification
    {
        public AppUser AppUser { get; set; }    


    }
}
