using System.Collections.Generic;
using _Test.Code.Features.Bugs.Configs;
using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Bugs.States;
using _Test.Code.Features.Movement.Contracts;
using _Test.Code.Features.Movement.Models;
using _Test.Code.Features.ResourceSpawn.Contracts;
using _Test.Code.Features.StateMachine.Contracts;
using _Test.Code.Features.Targeting;
using _Test.Code.Features.Targeting.Collectors;
using _Test.Code.Features.Targeting.Contracts;
using _Test.Code.Features.Targeting.Models;
using _Test.Code.Features.Targeting.Selectors;
using _Test.Code.Features.Targeting.Strategies;
using _Test.Code.Features.Timers.Contracts;
using UnityEngine;
using VContainer;
namespace _Test.Code.Features.Bugs.Factories
{
    public sealed class PredatorBugFactory
    {
        private readonly BugSceneContainer _sceneContainer;
        private readonly BugPoolProvider _bugPoolProvider;
        private readonly IMovementStrategyFactory _movementStrategyFactory;
        private readonly TargetSelectorService _targetSelectorService;
        private readonly IResourceManager _resourceManager;
        private readonly Contracts.IBugRegistry _bugRegistry;
        private readonly BugConsumeService _bugConsumeService;
        private readonly BugSettings _settings = new(
            new BaseMoveData(MovementType.GroundXZ, 7f),
            splitSatiety: 3,
            lifetimeSeconds: 10f,
            splitBehavior: new DefaultSplit());
        private readonly IObjectResolver _objectResolver;

        public PredatorBugFactory(
            BugSceneContainer sceneContainer,
            BugPoolProvider bugPoolProvider,
            IMovementStrategyFactory movementStrategyFactory,
            TargetSelectorService targetSelectorService,
            IResourceManager resourceManager,
            Contracts.IBugRegistry bugRegistry,
            BugConsumeService bugConsumeService,
            IObjectResolver objectResolver)
        {
            _sceneContainer = sceneContainer;
            _bugPoolProvider = bugPoolProvider;
            _movementStrategyFactory = movementStrategyFactory;
            _targetSelectorService = targetSelectorService;
            _resourceManager = resourceManager;
            _bugRegistry = bugRegistry;
            _bugConsumeService = bugConsumeService;
            _objectResolver = objectResolver;
        }

        public BugAgentContainer Create(InternalIntId bugId, Vector3 position)
        {
            var pool = _bugPoolProvider.GetOrCreate(_sceneContainer.PredatorPrefab, nameof(BugKind.Predator));
            var view = pool.Rent();
            view.transform.position = position;

            var eatingTargetSelector = new ConfiguredTargetSelector(
                new List<ITargetCollector>
                {
                    new ResourceTargetCollector(),
                    new BugTargetCollector(BugKind.All)
                },
                new RandomTargetSelectionStrategy());

            var runtimeData = new RuntimeData(BugKind.Predator, _settings);
            var movementStrategy = _movementStrategyFactory.Create(runtimeData.Settings.MoveData);
            var stateContext = new BugStateContext(view, runtimeData, movementStrategy);

            var states = new List<IState>
            {
                new EatingState(_targetSelectorService, _resourceManager, _bugRegistry, _bugConsumeService, eatingTargetSelector),
                new IdleState()
            };

            var lifeTimer = _objectResolver.Resolve<ITimer>();
            var lifetimeComponent = new BugLifetimeComponent(lifeTimer, _settings.LifetimeSeconds);

            var stateMachine = new BugStateMachine(stateContext, states);
            var agentContainer = new BugAgentContainer(bugId, view, runtimeData, pool, stateContext, stateMachine);
            agentContainer.AttachLifetime(lifetimeComponent);
            
            //циклическая зависимость
            stateContext.Owner = agentContainer;
            
            return agentContainer;
        }
    }
}
