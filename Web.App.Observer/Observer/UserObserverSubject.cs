using System.Collections.Generic;
using BaseProject.Models;

namespace Web.App.Observer.Observer
{
    public class UserObserverSubject
    {
        private readonly List<IUserObserver> _userObservers;

        public UserObserverSubject(List<IUserObserver> userObservers)
        {
            _userObservers = userObservers;
        }

        public void RegisterObserver(IUserObserver userObserver)
        {
            _userObservers.Add(userObserver);
        }

        public void RemoveObserver(IUserObserver userObserver)
        {
            _userObservers.Remove(userObserver);
        }
        public void NotifyObservers(AppUser appUser)
        {
            _userObservers.ForEach(x =>
            {
                x.UserCreated(appUser);
            });
        }
    }
}
