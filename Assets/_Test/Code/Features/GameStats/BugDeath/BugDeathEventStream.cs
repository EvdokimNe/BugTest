using _Test.Code.Features.Bugs.Models;
using R3;
namespace _Test.Code.Features.GameStats.BugDeath
{
    public sealed class BugDeathEventStream
    {
        public Subject<BugKind> BugDied { get; } = new();
    }
}
