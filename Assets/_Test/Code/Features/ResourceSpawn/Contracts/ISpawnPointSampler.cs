using Test.Code.Features.ResourceSpawn.Models;
using UnityEngine;

namespace Test.Code.Features.ResourceSpawn.Contracts
{
    public interface ISpawnPointSampler
    {
        Vector3 Sample(SpawnArea area);
    }
}
