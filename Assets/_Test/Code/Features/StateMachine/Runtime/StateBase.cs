using _Test.Code.Features.StateMachine.Contracts;
namespace _Test.Code.Features.StateMachine.Runtime
{
    public abstract class StateBase<TContext> : IState where TContext : class, IStateContext
    {
        protected TContext Context { get; private set; }
        public bool NeedExit { get; private set; }

        public void Setup(IStateContext context)
        {
            Context = context as TContext;
            OnSetup();
        }

        public virtual bool CanExit()
        {
            return true;
        }

        public virtual bool ShouldBeActive()
        {
            return false;
        }

        public void OnEnter()
        {
            NeedExit = false;
            OnEnterState();
        }

        public virtual void Update()
        {
        }

        protected void RequestExit()
        {
            NeedExit = true;
        }

        protected virtual void OnSetup()
        {
        }

        protected virtual void OnEnterState()
        {
        }
    }
}
