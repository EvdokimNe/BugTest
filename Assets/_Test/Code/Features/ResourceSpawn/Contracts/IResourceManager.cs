using System.Collections.Generic;
using Test.Code.Features.ResourceSpawn.Models;
using Test.Code.Features.ResourceSpawn.Scene;
using Test.Code.Features.Targeting.Models;
using UnityEngine;
using uPools;

namespace Test.Code.Features.ResourceSpawn.Contracts
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
