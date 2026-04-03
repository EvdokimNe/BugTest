using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Bugs.Factories;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Bugs.Scene;
using _Test.Code.Features.Colony;
using _Test.Code.Features.GameStats.BugDeath;
using _Test.Code.Features.Movement.Contracts;
using _Test.Code.Features.Movement.Runtime;
using _Test.Code.Features.Split;
using _Test.Code.Features.Split.Runtime;
using _Test.Code.Features.Targeting;
using _Test.Code.Features.Targeting.Collectors;
using _Test.Code.Features.Targeting.Strategies;
using UnityEngine;
using VContainer;
namespace _Test.Code.Features.Bugs
{
    public sealed class BugsInstaller : MonoBehaviour
    {
        [SerializeField] private BugView _workerPrefab;
        [SerializeField] private BugView _predatorPrefab;
        [SerializeField] private Transform _spawnPoint;

        public void Install(IContainerBuilder builder)
        {
            var sceneSetup = new BugSceneContainer(_workerPrefab, _predatorPrefab, _spawnPoint);

            builder.RegisterInstance(sceneSetup);
            
            builder.Register<MovementStrategyFactory>(Lifetime.Singleton).As<IMovementStrategyFactory>();

            builder.Register<TargetSelectorService>(Lifetime.Singleton);
            builder.Register<ResourceTargetCollectorProcessor>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BugTargetCollectorProcessor>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<RandomTargetSelectionStrategyProcessor>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<BugPoolProvider>(Lifetime.Singleton);
            builder.Register<BugIdProvider>(Lifetime.Singleton);

            builder.Register<BugRegistry>(Lifetime.Singleton).As<IBugRegistry>();
            builder.Register<BugBehaviorService>(Lifetime.Singleton);
            builder.Register<BugDeathService>(Lifetime.Singleton);
            builder.Register<DefaultSplitProcessor>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SplitWithMutationChanceProcessor>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BugSplitResolverService>(Lifetime.Singleton);
            builder.Register<BugSplitService>(Lifetime.Singleton);
            builder.Register<BugColonyRespawnService>(Lifetime.Singleton);

            builder.Register<BugDeathEventStream>(Lifetime.Singleton);
            builder.Register<BugDeathCountersService>(Lifetime.Singleton);
            
            builder.Register<BugDespawnService>(Lifetime.Singleton);
            builder.Register<BugConsumeService>(Lifetime.Singleton);

            builder.Register<WorkerBugFactory>(Lifetime.Singleton);
            builder.Register<PredatorBugFactory>(Lifetime.Singleton);
            builder.Register<AttachOptionalComponentsHelper>(Lifetime.Singleton);
            
            builder.Register<BugSpawnService>(Lifetime.Singleton);
        }
    }
}
