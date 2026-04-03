using System;
using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Bugs.Runtime;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Test.Code.Features.BugLifecycle.Runtime
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
