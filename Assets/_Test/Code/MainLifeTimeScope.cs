using _Test.Code.Features.Bugs;
using _Test.Code.Features.CoreLoop;
using _Test.Code.Features.GameStats.BugDeath.View;
using _Test.Code.Features.ResourceSpawn;
using _Test.Code.Features.Timers;
using UnityEngine;
using VContainer;
using VContainer.Unity;
namespace _Test.Code
{
    public sealed class MainLifeTimeScope : LifetimeScope
    {
        [SerializeField] private BugsInstaller _bugsInstaller;
        [SerializeField] private ResourceSpawnInstaller _resourceSpawnInstaller;
        
        [SerializeField] private BugDeathCountersActiveView _deathCountersActiveView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_deathCountersActiveView);
            
            new TimerInstaller().Install(builder);
            
            _resourceSpawnInstaller.Install(builder);
            _bugsInstaller.Install(builder);
            
            builder.Register<GameplayRunner>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            
            builder.RegisterEntryPoint<EntryPoint>();
        }
    }
}
