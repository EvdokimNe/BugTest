using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Scene;
using _Test.Code.Features.Bugs.States;
using _Test.Code.Features.Split.Contracts;
using _Test.Code.Features.Targeting.Models;
using _Test.Code.Shared;
using uPools;

namespace _Test.Code.Features.Bugs.Runtime
{
    public sealed class BugAgentContainer
    {
        public InternalIntId Id { get; }
        public BugKind Kind { get; }
        public BugView View { get; }
        public RuntimeData RuntimeData { get; }
        public ObjectPool<BugView> Pool { get; }
        public BugStateContext StateContext { get; }
        public BugStateMachine StateMachine { get; }
        
        public BugLifetimeComponent LifetimeComponent { get; private set; }
        public ISplitBehavior SplitBehavior { get; private set; }

        public BugAgentContainer(
            InternalIntId id,
            BugKind kind,
            BugView view,
            RuntimeData runtimeData,
            ObjectPool<BugView> pool,
            BugStateContext stateContext,
            BugStateMachine stateMachine)
        {
            Id = id;
            Kind = kind;
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

        public void AttachSplitBehavior(ISplitBehavior splitBehavior)
        {
            SplitBehavior = splitBehavior;
        }
    }
}
