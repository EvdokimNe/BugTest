using _Test.Code.Features.ResourceSpawn.Contracts;
using _Test.Code.Features.ResourceSpawn.Models;
using UnityEngine;
namespace _Test.Code.Features.ResourceSpawn.Services
{
    public sealed class RandomSpawnPointSampler : ISpawnPointSampler
    {
        public Vector3 Sample(SpawnArea area)
        {
            var halfX = area.SizeXZ.x * 0.5f;
            var halfZ = area.SizeXZ.y * 0.5f;

            var x = Random.Range(area.Center.x - halfX, area.Center.x + halfX);
            var z = Random.Range(area.Center.z - halfZ, area.Center.z + halfZ);

            return new Vector3(x, area.Center.y, z);
        }
    }
}
