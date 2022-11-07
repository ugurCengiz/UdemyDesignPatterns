using BaseProject.Models;

namespace Web.App.Observer.Observer
{
    public interface IUserObserver
    {
        void UserCreated(AppUser appUser);

    }
}
