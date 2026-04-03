using _Test.Code.Features.ResourceSpawn.Models;
using UnityEngine;
namespace _Test.Code.Features.ResourceSpawn.Contracts
{
    public interface ISpawnPointSampler
    {
        Vector3 Sample(SpawnArea area);
    }
}
