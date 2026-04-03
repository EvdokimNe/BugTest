using System;
using _Test.Code.Features.Bugs.Configs;
using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Split.Contracts;
using Random = UnityEngine.Random;

namespace _Test.Code.Features.Split.Runtime
{
    public sealed class SplitWithMutationChanceProcessor : ISplitProcessor
    {
        public Type ConfigType => typeof(SplitWithMutationChance);

        public void Resolve(BugAgent bug, int populationCount, out BugKind firstChildKind, out BugKind secondChildKind)
        {
            firstChildKind = bug.RuntimeData.Kind;
            secondChildKind = bug.RuntimeData.Kind;

            if (bug.RuntimeData.Kind != BugKind.Worker)
                return;

            if (bug.RuntimeData.Settings.SplitBehavior is not SplitWithMutationChance config)
                return;

            var shouldMutate = populationCount > config.MutationPopulationThreshold &&
                               Random.value <= config.MutationChance;

            if (shouldMutate)
            {
                secondChildKind = BugKind.Predator;
            }
        }
    }
}
