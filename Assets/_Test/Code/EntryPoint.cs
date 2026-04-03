using _Test.Code.Features.CoreLoop;
using Test.Code.Features.ResourceSpawn.Contracts;
using UnityEngine;
using VContainer.Unity;

namespace Test.Code
{
    public sealed class EntryPoint : IStartable
    {
        private readonly GameplayRunner _runner;
        private readonly IResourceSpawner _resourceSpawner;
        
        public EntryPoint(GameplayRunner runner, IResourceSpawner resourceSpawner)
        {
            _runner = runner;
            _resourceSpawner = resourceSpawner;
        }
        
        public void Start()
        {
            Debug.Log("[Test] EntryPoint started");
            _runner.Start();
            _resourceSpawner.Start();
        }
    }
}
