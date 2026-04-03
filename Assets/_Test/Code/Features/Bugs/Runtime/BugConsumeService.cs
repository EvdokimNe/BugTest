using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.ResourceSpawn.Contracts;
using _Test.Code.Features.ResourceSpawn.Models;
using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Bugs.Runtime
{
    public sealed class BugConsumeService
    {
        private readonly IResourceManager _resourceManager;
        private readonly IBugRegistry _bugRegistry;
        private readonly BugDespawnService _bugDespawnService;

        public BugConsumeService(
            IResourceManager resourceManager,
            IBugRegistry bugRegistry,
            BugDespawnService bugDespawnService)
        {
            _resourceManager = resourceManager;
            _bugRegistry = bugRegistry;
            _bugDespawnService = bugDespawnService;
        }

        public bool TryConsume(BugAgent consumer, TargetInfo target)
        {
            switch (target.Kind)
            {
                case TargetKind.Resource:
                    return TryConsumeResource(consumer, target.Id);
                case TargetKind.Bug:
                    return TryConsumeBug(consumer, target.Id);
                default:
                    return false;
            }
        }

        private bool TryConsumeResource(BugAgent consumer, InternalIntId targetId)
        {
            if (!_resourceManager.TryGet(targetId, out var resource))
                return false;

            resource.State = ResourceState.InProcess;
            _resourceManager.Remove(targetId);
            resource.Pool.Return(resource.View);
            consumer.RuntimeData.Satiety += 1;
            return true;
        }

        private bool TryConsumeBug(BugAgent consumer, InternalIntId targetId)
        {
            if (!_bugRegistry.TryGet(targetId, out var targetBug))
                return false;

            if (targetBug.Id.Equals(consumer.Id))
                return false;

            _bugDespawnService.Despawn(targetId);
            consumer.RuntimeData.Satiety += 1;
            return true;
        }
    }
}
