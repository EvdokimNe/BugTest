using _Test.Code.Features.Split.Contracts;
namespace _Test.Code.Features.Bugs.Configs
{
    public sealed class DefaultSplit : ISplitBehavior
    {
        public int SplitSatiety { get; }

        public DefaultSplit(int splitSatiety)
        {
            SplitSatiety = splitSatiety;
        }
    }
}
