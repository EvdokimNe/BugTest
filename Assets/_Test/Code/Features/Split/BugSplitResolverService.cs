using System;
using System.Collections.Generic;
using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Split.Contracts;
namespace _Test.Code.Features.Split
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

        public bool TryResolve(BugAgentContainer bug, out BugKind firstChildKind, out BugKind secondChildKind)
        {
            firstChildKind = BugKind.None;
            secondChildKind = BugKind.None;
            
            var behaviorConfig = bug.SplitBehavior;
            if (behaviorConfig == null)
            {
                return false;
            }

            if (_processors.TryGetValue(behaviorConfig.GetType(), out var processor))
            {
                processor.Resolve(behaviorConfig, bug, out firstChildKind, out secondChildKind);
            }

            return true;
        }
    }
}
