using _Test.Code.Features.Targeting.Models;
using _Test.Code.Shared;
using UnityEngine;
namespace _Test.Code.Features.ResourceSpawn.Scene
{
    public sealed class ResourceView : MonoBehaviour
    {
        [SerializeField] private string _typeId = "resource.default";
        [SerializeField] private float _radius = 0.35f;

        public InternalStringId TypeId => new InternalStringId(_typeId);
        public float Radius => _radius;
    }
}
