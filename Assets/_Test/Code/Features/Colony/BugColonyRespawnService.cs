using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Bugs.Runtime;
using UnityEngine;

namespace _Test.Code.Features.Colony
{
    public sealed class BugColonyRespawnService
    {
        private readonly IBugRegistry _bugRegistry;
        private readonly BugSpawnService _bugSpawnService;
        private readonly BugSceneContainer _sceneContainer;

        public BugColonyRespawnService(IBugRegistry bugRegistry, BugSpawnService bugSpawnService, BugSceneContainer sceneContainer)
        {
            _bugRegistry = bugRegistry;
            _bugSpawnService = bugSpawnService;
            _sceneContainer = sceneContainer;
        }

        public void Tick()
        {
            if (_bugRegistry.Count != 0)
                return;

            var spawnPosition = _sceneContainer.SpawnPoint != null ? _sceneContainer.SpawnPoint.position : Vector3.zero;
            _bugSpawnService.SpawnWorker(spawnPosition);
        }
    }
}
