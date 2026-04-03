using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Bugs.Runtime;
namespace _Test.Code.Features.Split.Runtime
{
    public sealed class BugDeathService
    {
        private readonly IBugRegistry _bugRegistry;
        private readonly BugDespawnService _bugDespawnService;

        public BugDeathService(IBugRegistry bugRegistry, BugDespawnService bugDespawnService)
        {
            _bugRegistry = bugRegistry;
            _bugDespawnService = bugDespawnService;
        }

        public void Tick()
        {
            foreach (var bug in _bugRegistry.Snapshot)
            {
                if (!bug.RuntimeData.IsAlive)
                    continue;

                if (bug.LifetimeComponent != null && bug.LifetimeComponent.IsExpired)
                {
                    _bugDespawnService.Despawn(bug.Id);
                }
            }
        }
    }
}
