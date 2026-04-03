using Test.Code.Features.Bugs.Contracts;
using Test.Code.Features.Bugs.Models;
using UnityEngine;

namespace Test.Code.Features.Bugs.Runtime
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

        public BugAgent SpawnWorker(Vector3 position)
        {
            var bug = _workerBugFactory.Create(_bugIdProvider.Create(), position);
            _bugRegistry.Add(bug);
            return bug;
        }

        public BugAgent SpawnPredator(Vector3 position)
        {
            var bug = _predatorBugFactory.Create(_bugIdProvider.Create(), position);
            _bugRegistry.Add(bug);
            return bug;
        }
    }
}
