using System.Collections.Generic;
using Test.Code.Features.StateMachine.Contracts;
using Test.Code.Features.StateMachine.Runtime;

namespace Test.Code.Features.Bugs.Runtime
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
