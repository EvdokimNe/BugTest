using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Bugs.Factories;
using _Test.Code.Features.Bugs.Models;
using UnityEngine;
namespace _Test.Code.Features.Bugs.Runtime
{
    public sealed class BugSpawnService
    {
        private readonly BugIdProvider _bugIdProvider;
        private readonly IBugRegistry _bugRegistry;
        private readonly WorkerBugFactory _workerBugFactory;
        private readonly PredatorBugFactory _predatorBugFactory;

        public BugSpawnService(
            BugIdProvider bugIdProvider,
            IBugRegistry bugRegistry,
            WorkerBugFactory workerBugFactory,
            PredatorBugFactory predatorBugFactory)
        {
            _bugIdProvider = bugIdProvider;
            _bugRegistry = bugRegistry;
            _workerBugFactory = workerBugFactory;
            _predatorBugFactory = predatorBugFactory;
        }

        public BugAgentContainer SpawnByKind(BugKind bugKind, Vector3 position)
        {
            return bugKind switch
            {
                BugKind.Worker => SpawnWorker(position),
                BugKind.Predator => SpawnPredator(position),
                _ => null
            };
        }

        public BugAgentContainer SpawnWorker(Vector3 position)
        {
            var bug = _workerBugFactory.Create(_bugIdProvider.Create(), position);
            _bugRegistry.Add(bug);
            return bug;
        }

        public BugAgentContainer SpawnPredator(Vector3 position)
        {
            var bug = _predatorBugFactory.Create(_bugIdProvider.Create(), position);
            _bugRegistry.Add(bug);
            return bug;
        }
    }
}
