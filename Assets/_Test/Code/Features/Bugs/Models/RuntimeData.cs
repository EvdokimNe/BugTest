using _Test.Code.Features.Bugs.Configs;
using _Test.Code.Features.Targeting.Contracts;
namespace _Test.Code.Features.Bugs.Models
{
    public sealed class RuntimeData
    {
        public BugSettings Settings { get; }

        public int Satiety { get; set; }
        public bool IsAlive { get; set; }

        public RuntimeData(BugSettings settings)
        {
            Settings = settings;
            IsAlive = true;
        }
    }
}
