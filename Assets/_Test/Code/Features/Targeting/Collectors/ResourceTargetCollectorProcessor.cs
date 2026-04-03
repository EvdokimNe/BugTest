using System;
using System.Collections.Generic;
using Test.Code.Features.Bugs.Runtime;
using Test.Code.Features.ResourceSpawn.Contracts;
using Test.Code.Features.ResourceSpawn.Models;
using Test.Code.Features.Targeting.Contracts;
using Test.Code.Features.Targeting.Models;
using Test.Code.Features.Targeting.Runtime.Collectors;

namespace Test.Code.Features.Bugs.Runtime.Targeting
{
    public sealed class ResourceTargetCollectorProcessor : ITargetCollectorProcessor
    {
        private readonly IResourceManager _resourceManager;

        public Type CollectorType => typeof(ResourceTargetCollector);

        public ResourceTargetCollectorProcessor(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void Collect(ITargetCollector collector, BugAgent requester, List<TargetInfo> buffer)
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
