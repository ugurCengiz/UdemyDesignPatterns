namespace Web.App.ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class ProcessHandler : IProcessHandler
    {

        private IProcessHandler nextprocessHandler;

        public IProcessHandler SetNext(IProcessHandler processHandler)
        {
            nextprocessHandler = processHandler;
            return nextprocessHandler;
        }

        public virtual object Handle(object o)
        {
            if (nextprocessHandler != null)
            {
                return nextprocessHandler.Handle(o);
            }

            return null;
        }
    }
}
