using Test.Code.Features.ResourceSpawn.Scene;
using Test.Code.Features.Targeting.Models;
using UnityEngine;
using uPools;

namespace Test.Code.Features.ResourceSpawn.Models
{
    public sealed class ResourceData
    {
        public InternalIntId InstanceId { get; }
        public InternalStringId TypeId { get; }
        public ResourceView View { get; }
        public ObjectPool<ResourceView> Pool { get; }

        public Vector3 Position { get; set; }
        public ResourceState State { get; set; }

        public ResourceData(
            InternalIntId instanceId,
            InternalStringId typeId,
            Vector3 position,
            ResourceState state,
            ResourceView view,
            ObjectPool<ResourceView> pool)
        {
            InstanceId = instanceId;
            TypeId = typeId;
            Position = position;
            State = state;
            View = view;
            Pool = pool;
        }
    }
}
