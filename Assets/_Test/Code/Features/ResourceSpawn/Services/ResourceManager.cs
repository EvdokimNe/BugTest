using System.Collections.Generic;
using _Test.Code.Features.ResourceSpawn.Contracts;
using _Test.Code.Features.ResourceSpawn.Models;
using _Test.Code.Features.ResourceSpawn.Scene;
using _Test.Code.Features.Targeting.Models;
using UnityEngine;
using uPools;
namespace _Test.Code.Features.ResourceSpawn.Services
{
    public sealed class ResourceManager : IResourceManager
    {
        private readonly Dictionary<InternalIntId, ResourceData> _resources = new Dictionary<InternalIntId, ResourceData>(32);
        private int _nextInstanceId = 1;

        public int ActiveCount => _resources.Count;
        public IReadOnlyCollection<ResourceData> Resources => _resources.Values;

        public bool TryAdd(
            InternalStringId typeId,
            Vector3 position,
            ResourceView view,
            ObjectPool<ResourceView> pool,
            ResourceState initialState,
            out ResourceData resource)
        {
            var instanceId = new InternalIntId(_nextInstanceId++);
            resource = new ResourceData(instanceId, typeId, position, initialState, view, pool);
            return _resources.TryAdd(instanceId, resource);
        }

        public bool TryGet(InternalIntId instanceId, out ResourceData resource)
        {
            return _resources.TryGetValue(instanceId, out resource);
        }

        public void Remove(InternalIntId instanceId)
        {
            _resources.Remove(instanceId);
        }
    }
}
