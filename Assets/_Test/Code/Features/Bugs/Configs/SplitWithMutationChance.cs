namespace Test.Code.Features.Bugs.Runtime
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
