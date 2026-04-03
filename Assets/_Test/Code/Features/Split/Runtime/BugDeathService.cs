using System.Collections.Generic;
using Test.Code.Features.Bugs.Contracts;
using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Bugs.Runtime;

namespace Test.Code.Features.BugLifecycle.Runtime
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
