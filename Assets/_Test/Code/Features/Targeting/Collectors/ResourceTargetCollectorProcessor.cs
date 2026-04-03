using System;
using System.Collections.Generic;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.ResourceSpawn.Contracts;
using _Test.Code.Features.ResourceSpawn.Models;
using _Test.Code.Features.Targeting.Contracts;
using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Targeting.Collectors
{
    public sealed class ResourceTargetCollectorProcessor : ITargetCollectorProcessor
    {
        private readonly IResourceManager _resourceManager;

        public Type CollectorType => typeof(ResourceTargetCollector);

        public ResourceTargetCollectorProcessor(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void Collect(ITargetCollector collector, BugAgentContainer requester, List<TargetInfo> buffer)
        {
            foreach (var resource in _resourceManager.Resources)
            {
                if (resource.State != ResourceState.Available)
                    continue;

                buffer.Add(TargetInfo.CreateResource(
                    resource.View.transform,
                    resource.Position,
                    resource.View.Radius,
                    new InternalIntId(resource.InstanceId.Value)));
            }
        }
    }
}
