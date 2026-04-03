using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Scene;
using _Test.Code.Features.Bugs.States;
using _Test.Code.Features.Targeting.Contracts;
using _Test.Code.Features.Targeting.Models;
using uPools;
namespace _Test.Code.Features.Bugs.Runtime
{
    public sealed class BugAgentContainer
    {
        public InternalIntId Id { get; }
        public BugView View { get; }
        public RuntimeData RuntimeData { get; }
        public ObjectPool<BugView> Pool { get; }
        public BugLifetimeComponent LifetimeComponent { get; private set; }
        public BugStateContext StateContext { get; }
        public BugStateMachine StateMachine { get; }

        public BugAgentContainer(
            InternalIntId id,
            BugView view,
            RuntimeData runtimeData,
            ObjectPool<BugView> pool,
            BugStateContext stateContext,
            BugStateMachine stateMachine)
        {
            Id = id;
            View = view;
            RuntimeData = runtimeData;
            Pool = pool;
            StateContext = stateContext;
            StateMachine = stateMachine;
        }
        
        public void AttachLifetime(BugLifetimeComponent lifetimeComponent)
        {
            LifetimeComponent = lifetimeComponent;
        }
    }
}
