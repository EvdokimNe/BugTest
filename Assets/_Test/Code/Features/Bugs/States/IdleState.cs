using _Test.Code.Features.StateMachine.Runtime;
namespace _Test.Code.Features.Bugs.States
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
