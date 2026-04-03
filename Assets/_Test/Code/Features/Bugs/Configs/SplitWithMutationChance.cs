using _Test.Code.Features.Split.Contracts;
namespace _Test.Code.Features.Bugs.Configs
{
    public sealed class SplitWithMutationChance : ISplitBehavior
    {
        public int MutationPopulationThreshold { get; }
        public float MutationChance { get; }

        public SplitWithMutationChance(int mutationPopulationThreshold, float mutationChance)
        {
            MutationPopulationThreshold = mutationPopulationThreshold;
            MutationChance = mutationChance;
        }
    }
}
