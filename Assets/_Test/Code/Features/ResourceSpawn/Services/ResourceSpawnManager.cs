using Test.Code.Features.ResourceSpawn.Contracts;
using Test.Code.Features.ResourceSpawn.Models;
using Test.Code.Features.ResourceSpawn.Runtime;
using Test.Code.Features.ResourceSpawn.Scene;
using Test.Code.Features.Timers.Contracts;
using VContainer.Unity;

namespace Test.Code.Features.ResourceSpawn.Services
{
    public sealed class ResourceSpawnManager : IResourceSpawner, ITickable
    {
        private readonly IResourceManager _resourceManager;
        private readonly ISpawnZone _spawnZone;
        private readonly ISpawnPointSampler _spawnPointSampler;
        private readonly ResourcePoolProvider _poolProvider;
        private readonly ResourceSpawnSettings _settings;
        private readonly ITimer _spawnTimer;
        private readonly ResourceView _resourcePrefab;

        private bool _isRunning;

        public ResourceSpawnManager(
            IResourceManager resourceManager,
            ISpawnZone spawnZone,
            ISpawnPointSampler spawnPointSampler,
            ResourcePoolProvider poolProvider,
            ResourceSpawnSettings settings,
            ITimer spawnTimer,
            ResourceView resourcePrefab)
        {
            _resourceManager = resourceManager;
            _spawnZone = spawnZone;
            _spawnPointSampler = spawnPointSampler;
            _poolProvider = poolProvider;
            _settings = settings;
            _spawnTimer = spawnTimer;
            _resourcePrefab = resourcePrefab;

            _spawnTimer.Setup(_settings.SpawnIntervalSeconds);
        }

        public void Start()
        {
            SpawnOnce();
            
            _spawnTimer.Restart();
            _isRunning = true;
        }
        public void Stop()
        {
            _isRunning = false;
            _spawnTimer.Stop();
        }

        public void Tick()
        {
            if (!_isRunning)
                return;

            if (!_spawnTimer.IsFinished)
                return;

            if (_resourceManager.ActiveCount >= _settings.MaxActiveResources)
                return;

            _spawnTimer.Restart();
            
            SpawnOnce();
        }

        private void SpawnOnce()
        {
            var area = _spawnZone.GetArea();
            var spawnPosition = _spawnPointSampler.Sample(area);

            var pool = _poolProvider.GetOrCreate(_resourcePrefab, _resourcePrefab.TypeId.Value);
            var view = pool.Rent();
             
            view.transform.position = spawnPosition;
            
            var added = _resourceManager.TryAdd(
                _resourcePrefab.TypeId,
                spawnPosition,
                view,
                pool,
                ResourceState.Available,
                out var resourceData);

            if (!added)
            {
                pool.Return(view);
                return;
            }
        }
    }
}
