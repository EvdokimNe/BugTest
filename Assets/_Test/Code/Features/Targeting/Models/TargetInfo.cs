using UnityEngine;
namespace _Test.Code.Features.Targeting.Models
{
    public sealed class TargetInfo
    {
        private readonly Vector3 _fallbackPosition;

        public TargetKind Kind { get; }
        public Transform Transform { get; }
        public float Radius { get; }
        public InternalIntId Id { get; }

        public Vector3 Position => Transform != null ? Transform.position : _fallbackPosition;

        private TargetInfo(TargetKind kind, Transform transform, Vector3 fallbackPosition, float radius, InternalIntId id)
        {
            Kind = kind;
            Transform = transform;
            _fallbackPosition = fallbackPosition;
            Radius = radius;
            Id = id;
        }

        public static TargetInfo CreateResource(Transform transform, Vector3 position, float radius, InternalIntId id)
        {
            return new TargetInfo(TargetKind.Resource, transform, position, radius, id);
        }

        public static TargetInfo CreateBug(Transform transform, Vector3 position, float radius, InternalIntId id)
        {
            return new TargetInfo(TargetKind.Bug, transform, position, radius, id);
        }
    }
}
