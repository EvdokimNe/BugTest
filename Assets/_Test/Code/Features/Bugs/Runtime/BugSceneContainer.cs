using _Test.Code.Features.Bugs.Scene;
using UnityEngine;
namespace _Test.Code.Features.Bugs.Runtime
{
    public sealed class BugSceneContainer
    {
        public BugView WorkerPrefab { get; }
        public BugView PredatorPrefab { get; }
        public Transform SpawnPoint { get; }

        public BugSceneContainer(BugView workerPrefab, BugView predatorPrefab, Transform spawnPoint)
        {
            WorkerPrefab = workerPrefab;
            PredatorPrefab = predatorPrefab;
            SpawnPoint = spawnPoint;
        }
    }
}
