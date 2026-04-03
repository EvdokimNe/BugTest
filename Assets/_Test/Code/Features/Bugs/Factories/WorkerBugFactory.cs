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
using _Test.Code.Features.Targeting.Selectors;
using _Test.Code.Features.Targeting.Strategies;
using _Test.Code.Shared;
using UnityEngine;
using VContainer;
namespace _Test.Code.Features.Bugs.Factories
{
    //не совсем фабрика
    public sealed class WorkerBugFactory
    {
        private readonly BugSceneContainer _sceneContainer;
        private readonly BugPoolProvider _bugPoolProvider;
        private readonly IMovementStrategyFactory _movementStrategyFactory;
        private readonly IObjectResolver _objectResolver;

        private readonly BugSettings _defaultSettings = new BugSettings(
            new BaseMoveData(MovementType.GroundXZ, 5f),
            splitSatiety: 2,
            lifetimeSeconds: -1f,
            splitBehavior: new SplitWithMutationChance(2,10, 0.1f));

        public WorkerBugFactory(
            BugSceneContainer sceneContainer,
            BugPoolProvider bugPoolProvider,
            IMovementStrategyFactory movementStrategyFactory,
            IObjectResolver objectResolver)
        {
            _sceneContainer = sceneContainer;
            _bugPoolProvider = bugPoolProvider;
            _movementStrategyFactory = movementStrategyFactory;
            _objectResolver = objectResolver;
        }

        public BugAgentContainer Create(InternalIntId bugId, Vector3 position)
        {
            var pool = _bugPoolProvider.GetOrCreate(_sceneContainer.WorkerPrefab, nameof(BugKind.Worker));
            var view = pool.Rent();
            view.transform.position = position;

            var eatingTargetSelector = new ConfiguredTargetSelector(
                new List<ITargetCollector>
                {
                    new ResourceTargetCollector()
                },
                new RandomTargetSelectionStrategy());

            var runtimeData = new RuntimeData();
            var movementStrategy = _movementStrategyFactory.Create(_defaultSettings.MoveData);
            var stateContext = new BugStateContext(view, runtimeData, movementStrategy);

            var states = new List<IState>
            {
                _objectResolver.Resolve<EatingState>().SetupState(eatingTargetSelector),
                _objectResolver.Resolve<IdleState>()
            };

            var stateMachine = new BugStateMachine(stateContext, states);
            var agentContainer = new BugAgentContainer(bugId,BugKind.Worker, view, runtimeData, pool, stateContext, stateMachine, _defaultSettings.SplitBehavior);
            
            //циклическая зависимость
            stateContext.Owner = agentContainer;
            return agentContainer;
        }
    }
}
