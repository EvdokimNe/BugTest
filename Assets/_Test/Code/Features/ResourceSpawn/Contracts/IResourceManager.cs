using System.Collections.Generic;
using _Test.Code.Features.ResourceSpawn.Models;
using _Test.Code.Features.ResourceSpawn.Scene;
using _Test.Code.Features.Targeting.Models;
using _Test.Code.Shared;
using UnityEngine;
using uPools;
namespace _Test.Code.Features.ResourceSpawn.Contracts
{
    public interface IResourceManager
    {
        int ActiveCount { get; }
        IReadOnlyCollection<ResourceData> Resources { get; }

        bool TryAdd(
            InternalStringId typeId,
            Vector3 position,
            ResourceView view,
            ObjectPool<ResourceView> pool,
            ResourceState initialState,
            out ResourceData resource);

        bool TryGet(InternalIntId instanceId, out ResourceData resource);
        void Remove(InternalIntId instanceId);
    }
}
