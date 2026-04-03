using _Test.Code.Features.Split.Contracts;
namespace _Test.Code.Features.Bugs.Configs
{
    public sealed class SplitWithMutationChance : ISplitBehavior
    {
        public int SplitSatiety { get; }
        
        public int MutationPopulationThreshold { get; }
        public float MutationChance { get; }

        public SplitWithMutationChance(int splitSatiety, int mutationPopulationThreshold, float mutationChance)
        {
            SplitSatiety = splitSatiety;
            MutationPopulationThreshold = mutationPopulationThreshold;
            MutationChance = mutationChance;
        }
       
    }
}
