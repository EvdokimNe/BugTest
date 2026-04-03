using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Scene;
using _Test.Code.Features.Bugs.States;
using _Test.Code.Features.Targeting.Contracts;
using _Test.Code.Features.Targeting.Models;
using uPools;
namespace _Test.Code.Features.Bugs.Runtime
{
    public sealed class BugAgent
    {
        public InternalIntId Id { get; }
        public BugView View { get; }
        public RuntimeData RuntimeData { get; }
        public ITargetSelector TargetSelector { get; }
        public ObjectPool<BugView> Pool { get; }
        public BugLifetimeComponent LifetimeComponent { get; }
        public BugStateContext StateContext { get; }
        public BugStateMachine StateMachine { get; }

        public BugAgent(
            InternalIntId id,
            BugView view,
            RuntimeData runtimeData,
            ITargetSelector targetSelector,
            ObjectPool<BugView> pool,
            BugLifetimeComponent lifetimeComponent,
            BugStateContext stateContext,
            BugStateMachine stateMachine)
        {
            Id = id;
            View = view;
            RuntimeData = runtimeData;
            TargetSelector = targetSelector;
            Pool = pool;
            LifetimeComponent = lifetimeComponent;
            StateContext = stateContext;
            StateMachine = stateMachine;
        }
    }
}
