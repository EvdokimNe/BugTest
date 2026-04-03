using _Test.Code.Features.Bugs.Models;
using R3;
namespace _Test.Code.Features.GameStats.BugDeath
{
    public sealed class BugDeathCountersService
    {
        private readonly ReactiveProperty<int> _deadWorkersCount = new(0);
        private readonly ReactiveProperty<int> _deadPredatorsCount = new(0);

        public ReactiveProperty<int> DeadWorkersCount => _deadWorkersCount;
        public ReactiveProperty<int> DeadPredatorsCount => _deadPredatorsCount;

        public BugDeathCountersService(BugDeathEventStream deathEventStream)
        {
            deathEventStream.BugDied.Subscribe(OnBugDied);
        }

        private void OnBugDied(BugKind bugKind)
        {
            switch (bugKind)
            {
                case BugKind.Worker:
                    _deadWorkersCount.Value += 1;
                    break;
                case BugKind.Predator:
                    _deadPredatorsCount.Value += 1;
                    break;
            }
        }
    }
}
