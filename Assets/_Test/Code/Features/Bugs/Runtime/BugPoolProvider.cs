using System.Collections.Generic;
using Test.Code.Features.Bugs.Scene;
using UnityEngine;
using uPools;

namespace Test.Code.Features.Bugs.Runtime
{
    public sealed class BugPoolProvider
    {
        private readonly Dictionary<string, ObjectPool<BugView>> _pools = new();

        public ObjectPool<BugView> GetOrCreate(BugView prefab, string poolId)
        {
            if (_pools.TryGetValue(poolId, out var pool))
                return pool;

            pool = new ObjectPool<BugView>(
                createFunc: () =>
                {
                    var instance = Object.Instantiate(prefab);
                    instance.gameObject.SetActive(true);
                    return instance;
                },
                onRent: view => view.gameObject.SetActive(true),
                onReturn: view => view.gameObject.SetActive(false),
                onDestroy: view => Object.Destroy(view.gameObject)
            );

            _pools[poolId] = pool;
            return pool;
        }
    }
}
