using System.Collections.Generic;
using _Test.Code.Features.StateMachine.Contracts;
using _Test.Code.Features.StateMachine.Runtime;
namespace _Test.Code.Features.Bugs.States
{
    public sealed class BugStateMachine
    {
        private readonly StateMachineRunner _runner;

        public BugStateMachine(BugStateContext context, IReadOnlyList<IState> states)
        {
            _runner = new StateMachineRunner(states, context, context);
        }

        public void Tick()
        {
            _runner.Tick();
        }
    }
}
