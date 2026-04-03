using System;
using System.Collections.Generic;
using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Bugs.Runtime;

namespace Test.Code.Features.BugLifecycle.Runtime
{
    public sealed class BugSplitResolverService
    {
        private readonly Dictionary<Type, ISplitProcessor> _processors = new();

        public BugSplitResolverService(IEnumerable<ISplitProcessor> processors)
        {
            foreach (var processor in processors)
            {
                _processors[processor.ConfigType] = processor;
            }
        }

        public void Resolve(BugAgent bug, int populationCount, out BugKind firstChildKind, out BugKind secondChildKind)
        {
            firstChildKind = bug.RuntimeData.Kind;
            secondChildKind = bug.RuntimeData.Kind;

            var config = bug.RuntimeData.Settings.SplitBehavior;
            if (config == null)
                return;

            if (_processors.TryGetValue(config.GetType(), out var processor))
            {
                processor.Resolve(bug, populationCount, out firstChildKind, out secondChildKind);
            }
        }
    }
}
