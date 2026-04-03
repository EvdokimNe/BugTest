using System.Collections.Generic;
using _Test.Code.Features.ResourceSpawn.Scene;
using UnityEngine;
using uPools;
namespace _Test.Code.Features.ResourceSpawn.Services
{
    public sealed class ResourcePoolProvider
    {
        private readonly Dictionary<string, ObjectPool<ResourceView>> _pools = new();

        public ObjectPool<ResourceView> GetOrCreate(ResourceView prefab, string poolId)
        {
            var key = string.IsNullOrEmpty(poolId) ? "default" : poolId;

            if (_pools.TryGetValue(key, out var existingPool))
            {
                return existingPool;
            }

            var pool = new ObjectPool<ResourceView>(
                createFunc: () =>
                {
                    var instance = Object.Instantiate(prefab);
                    instance.gameObject.SetActive(true);
                    return instance;
                },
                onRent: view =>
                {
                    view.gameObject.SetActive(true);
                },
                onReturn: view => view.gameObject.SetActive(false),
                onDestroy: view => Object.Destroy(view.gameObject)
            );

            _pools[key] = pool;
            return pool;
        }
    }
}
