using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Colony;
using _Test.Code.Features.Split.Runtime;
using VContainer.Unity;

namespace _Test.Code.Features.CoreLoop
{
    public sealed class GameplayRunner : ITickable
    {
        private readonly BugBehaviorService _behaviorService;
        private readonly BugDeathService _deathService;
        private readonly BugSplitService _splitService;
        private readonly BugColonyRespawnService _colonyRespawnService;
        private readonly IBugRegistry _bugRegistry;
        
        private bool _started;

        public GameplayRunner(
            BugBehaviorService behaviorService,
            BugDeathService deathService,
            BugSplitService splitService,
            BugColonyRespawnService colonyRespawnService,
            IBugRegistry bugRegistry)
        {
            _behaviorService = behaviorService;
            _deathService = deathService;
            _splitService = splitService;
            _colonyRespawnService = colonyRespawnService;
            _bugRegistry = bugRegistry;
        }

        public void Tick()
        {
            if (!_started)
            {
                return;
            }

            _bugRegistry.BuildSnapshot();
            
            _behaviorService.Tick();
            _deathService.Tick();
            _splitService.Tick();
            _colonyRespawnService.Tick();
        }
        public void Start()
        {
            _started = true;
        }
    }
}
