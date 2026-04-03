using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Runtime;
using UnityEngine;
namespace _Test.Code.Features.Split.Runtime
{
    public sealed class BugSplitService
    {
        public const float SplitSpawnOffset = 1f;
        
        private readonly IBugRegistry _bugRegistry;
        private readonly BugSpawnService _bugSpawnService;
        private readonly BugDespawnService _bugDespawnService;
        private readonly BugSplitResolverService _splitResolverService;

        public BugSplitService(
            IBugRegistry bugRegistry,
            BugSpawnService bugSpawnService,
            BugDespawnService bugDespawnService,
            BugSplitResolverService splitResolverService)
        {
            _bugRegistry = bugRegistry;
            _bugSpawnService = bugSpawnService;
            _bugDespawnService = bugDespawnService;
            _splitResolverService = splitResolverService;
        }

        public void Tick()
        {
            foreach (var bug in _bugRegistry.Snapshot)
            {
                if (!bug.RuntimeData.IsAlive)
                    continue;

                if (bug.RuntimeData.Satiety < bug.RuntimeData.Settings.SplitSatiety)
                    continue;

                Split(bug);
            }
        }

        private void Split(BugAgentContainer bug)
        {
            var populationCount = _bugRegistry.Count;
            var origin = bug.View.transform.position;
            var splitPositions = CreateSplitPositions(origin);
            _splitResolverService.Resolve(bug, populationCount, out var firstChildKind, out var secondChildKind);

            _bugDespawnService.Despawn(bug.Id, publishDeathEvent: false);

            SpawnByKind(firstChildKind, splitPositions.Item1);
            SpawnByKind(secondChildKind, splitPositions.Item2);
        }

        private void SpawnByKind(BugKind bugKind, Vector3 position)
        {
            switch (bugKind)
            {
                case BugKind.Worker:
                    _bugSpawnService.SpawnWorker(position);
                    break;
                case BugKind.Predator:
                    _bugSpawnService.SpawnPredator(position);
                    break;
            }
        }

        private (Vector3, Vector3) CreateSplitPositions(Vector3 origin)
        {
            var randomDirection2D = Random.insideUnitCircle.normalized;

            if (randomDirection2D == Vector2.zero)
            {
                randomDirection2D = Vector2.right;
            }

            var direction = new Vector3(randomDirection2D.x, 0f, randomDirection2D.y);
            var offset = direction * SplitSpawnOffset;

            return (origin + offset, origin - offset);
        }
    }
}
