using UnityEngine;
using WB.Base.Core.BaseClass.MovementBase;
namespace WB.Base.Core.Components.CameraFollowComponent
{
    using WB.Base.Core.Components.MovementComponent;
    public class CameraFollowComponent : MovementBase
    {
        #region Serialized values
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothTime;
        #endregion

        #region private values
        private Transform _targetTransform;
        #endregion

        private void Start()
        {
            _targetTransform = FindAnyObjectByType<MovementComponent>().transform;
        }

        protected override void OnUpdate()
        {
            CameraMovement(transform, _targetTransform.position + _offset, _smoothTime * Time.deltaTime);
        }
    }
}
