using System.Collections.Generic;
using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Bugs.Scene;
using Test.Code.Features.Bugs.States;
using Test.Code.Features.Movement.Contracts;
using Test.Code.Features.ResourceSpawn.Contracts;
using Test.Code.Features.StateMachine.Contracts;
using Test.Code.Features.Targeting.Contracts;
using Test.Code.Features.Targeting.Models;
using Test.Code.Features.Targeting.Runtime.Collectors;
using Test.Code.Features.Targeting.Runtime.Selectors;
using Test.Code.Features.Targeting.Runtime;
using Test.Code.Features.Timers.Contracts;
using Test.Code.Features.Movement.Models;
using UnityEngine;
using VContainer;

namespace Test.Code.Features.Bugs.Runtime
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
            new BaseMoveData(MovementType.GroundXZ, 15f),
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

        public BugAgent Create(InternalIntId bugId, Vector3 position)
        {
            var pool = _bugPoolProvider.GetOrCreate(_sceneContainer.PredatorPrefab, nameof(BugKind.Predator));
            var view = pool.Rent();
            view.transform.position = position;

            var targetSelector = new ConfiguredTargetSelector(
                new List<ITargetCollector>
                {
                    new ResourceTargetCollector(),
                    new BugTargetCollector(BugKind.All)
                },
                new RandomTargetSelectionStrategy());

            var runtimeData = new RuntimeData(BugKind.Predator, _settings, targetSelector);
            var movementStrategy = _movementStrategyFactory.Create(runtimeData.Settings.MoveData);
            var stateContext = new BugStateContext(view, runtimeData, movementStrategy);

            var states = new List<IState>
            {
                new EatingState(_targetSelectorService, _resourceManager, _bugRegistry, _bugConsumeService),
                new IdleState()
            };

            var lifeTimer = _objectResolver.Resolve<ITimer>();
            var lifetimeComponent = new BugLifetimeComponent(lifeTimer, _settings.LifetimeSeconds);

            var stateMachine = new BugStateMachine(stateContext, states);
            var agent = new BugAgent(bugId, view, runtimeData, runtimeData.TargetSelector, pool, lifetimeComponent, stateContext, stateMachine);
            stateContext.Owner = agent;
            return agent;
        }
    }
}
