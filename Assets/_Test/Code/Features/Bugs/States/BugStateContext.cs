using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Bugs.Scene;
using _Test.Code.Features.Movement.Contracts;
using _Test.Code.Features.StateMachine.Contracts;
using _Test.Code.Features.StateMachine.Runtime;
namespace _Test.Code.Features.Bugs.States
{
    public sealed class BugStateContext : IStateContext, IStateAccessor
    {
        public BugAgent Owner { get; set; }
        public BugView View { get; }
        public Models.RuntimeData RuntimeData { get; }
        public IMovementStrategy MovementStrategy { get; }

        public IState BeforeState { get; set; }
        public IState CurrentState { get; set; }
        public IState NextState { get; set; }
        
        public bool HasTransitionRequest { get; private set; }

        public BugStateContext(BugView view, Models.RuntimeData runtimeData, IMovementStrategy movementStrategy)
        {
            View = view;
            RuntimeData = runtimeData;
            MovementStrategy = movementStrategy;
        }

        public void RequestTransition()
        {
            HasTransitionRequest = true;
        }

        public void ConsumeTransitionRequest()
        {
            HasTransitionRequest = false;
        }
    }
}
