using UnityEngine;

namespace Test.Code.Features.ResourceSpawn.Models
{
    public readonly struct SpawnArea
    {
        public Vector3 Center { get; }
        public Vector2 SizeXZ { get; }

        public SpawnArea(Vector3 center, Vector2 sizeXz)
        {
            Center = center;
            SizeXZ = sizeXz;
        }
    }
}
