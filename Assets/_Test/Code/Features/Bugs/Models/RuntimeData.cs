using _Test.Code.Features.Bugs.Configs;
using _Test.Code.Features.Targeting.Contracts;
namespace _Test.Code.Features.Bugs.Models
{
    public sealed class RuntimeData
    {
        public BugKind Kind { get; }
        public BugSettings Settings { get; }

        public int Satiety { get; set; }
        public bool IsAlive { get; set; }

        public RuntimeData(BugKind kind, BugSettings settings)
        {
            Kind = kind;
            Settings = settings;
            IsAlive = true;
        }
    }
}
