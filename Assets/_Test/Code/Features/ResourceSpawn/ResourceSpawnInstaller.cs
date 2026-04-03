using _Test.Code.Features.ResourceSpawn.Configs;
using _Test.Code.Features.ResourceSpawn.Scene;
using _Test.Code.Features.ResourceSpawn.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Test.Code.Features.ResourceSpawn
{
    public sealed class ResourceSpawnInstaller : MonoBehaviour
    {
        [SerializeField] private PlaneSpawnZoneAuthoring _spawnZone;
        [SerializeField] private ResourceView _resourcePrefab;

        public void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(_spawnZone).AsImplementedInterfaces();
            builder.RegisterInstance(_resourcePrefab);

            builder.Register<ResourceSpawnSettings>(Lifetime.Singleton);
           
            builder.Register<RandomSpawnPointSampler>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<ResourcePoolProvider>(Lifetime.Singleton);
            
            builder.Register<ResourceManager>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<ResourceSpawnManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
