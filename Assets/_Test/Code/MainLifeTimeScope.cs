using _Test.Code.Features.CoreLoop;
using Test.Code.Features.Bugs;
using Test.Code.Features.Bugs.Scene;
using Test.Code.Features.ResourceSpawn;
using Test.Code.Features.Timers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Test.Code
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
