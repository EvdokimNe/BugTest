using _Test.Code.Features.ResourceSpawn.Contracts;
using _Test.Code.Features.ResourceSpawn.Models;
using UnityEngine;
namespace _Test.Code.Features.ResourceSpawn.Scene
{
    public sealed class PlaneSpawnZoneAuthoring : MonoBehaviour, ISpawnZone
    {
        [SerializeField] private Vector2 _size = new(10f, 10f);
        [SerializeField] private float _yLevel;

        public SpawnArea GetArea()
        {
            var center = transform.position;
            center.y = _yLevel;

            var sanitizedSize = new Vector2(Mathf.Abs(_size.x), Mathf.Abs(_size.y));
            return new SpawnArea(center, sanitizedSize);
        }

        private void OnDrawGizmosSelected()
        {
            var area = GetArea();
            var size = new Vector3(area.SizeXZ.x, 0.01f, area.SizeXZ.y);

            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(area.Center, size);
        }
    }
}
