using System;
using _Test.Code.Features.Bugs.Configs;
using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Split.Contracts;
using Random = UnityEngine.Random;

namespace _Test.Code.Features.Split.Runtime
{
    public sealed class SplitWithMutationChanceProcessor : ISplitProcessor
    {
        private readonly IBugRegistry _bugRegistry;
        public Type ConfigType => typeof(SplitWithMutationChance);

        public SplitWithMutationChanceProcessor(IBugRegistry bugRegistry)
        {
            _bugRegistry = bugRegistry;

        }

        public void Resolve(ISplitBehavior behavior, BugAgentContainer bug, out BugKind firstChildKind, out BugKind secondChildKind)
        {
            var splitWithMutation = behavior as SplitWithMutationChance;
            
            firstChildKind = bug.Kind;
            secondChildKind = bug.Kind;

            var shouldMutate = _bugRegistry.Bugs.Count > splitWithMutation.MutationPopulationThreshold &&
                               Random.value <= splitWithMutation.MutationChance;

            if (shouldMutate)
            {
                secondChildKind = BugKind.Predator;
            }
        }
    }
}
