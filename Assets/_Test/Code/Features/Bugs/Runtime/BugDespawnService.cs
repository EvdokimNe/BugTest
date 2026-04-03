using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.GameStats.BugDeath;
using _Test.Code.Features.Targeting.Models;
using _Test.Code.Shared;
namespace _Test.Code.Features.Bugs.Runtime
{
    public sealed class BugDespawnService
    {
        private readonly IBugRegistry _bugRegistry;
        private readonly BugDeathEventStream _deathEventStream;

        public BugDespawnService(IBugRegistry bugRegistry, BugDeathEventStream deathEventStream)
        {
            _bugRegistry = bugRegistry;
            _deathEventStream = deathEventStream;
        }

        public void Despawn(InternalIntId bugId, bool realDeath = true)
        {
            if (!_bugRegistry.TryGet(bugId, out var bug))
                return;

            if (realDeath)
            {
                _deathEventStream.BugDied.OnNext(bug.Kind);
            }

            bug.RuntimeData.IsAlive = false;
            bug.LifetimeComponent?.Stop();
            bug.LifetimeComponent?.Dispose();
            bug.Pool.Return(bug.View);
            
            _bugRegistry.Remove(bugId);
        }
    }
}
