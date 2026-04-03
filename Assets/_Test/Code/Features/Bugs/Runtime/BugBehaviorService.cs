using Test.Code.Features.Bugs.Contracts;

namespace Test.Code.Features.Bugs.Runtime
{
    public sealed class BugBehaviorService
    {
        private readonly IBugRegistry _bugRegistry;

        public BugBehaviorService(IBugRegistry bugRegistry)
        {
            _bugRegistry = bugRegistry;
        }

        public void Tick()
        {
            foreach (var bug in _bugRegistry.Snapshot)
            {
                if (!bug.RuntimeData.IsAlive)
                    continue;

                bug.StateMachine.Tick();
            }
        }
    }
}
