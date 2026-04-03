using Test.Code.Features.Bugs.Runtime;
using Test.Code.Features.StateMachine.Runtime;

namespace Test.Code.Features.Bugs.States
{
    public sealed class IdleState : StateBase<BugStateContext>
    {
        public override bool ShouldBeActive()
        {
            return Context.RuntimeData.IsAlive;
        }

        protected override void OnEnterState()
        {
            RequestExit();
        }
    }
}
