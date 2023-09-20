using UnityEngine;
using Zenject;
namespace WB.Base.Core.BaseClass.MovementBase
{
    using WB.Base.Core.BaseClass.UpdateBase;

    public class MovementBase : UpdateBase
    {
        private PlayerData playerData;
        private float _moveSpeed;

        [Inject]
        private void GetManager(DataManager manager)
        {
            /// <summary>
            /// Get DataManager from DI
            /// </summary>
            playerData = manager.GetPlayerData();
            _moveSpeed = playerData._playerMoveSpeed;
        }
        private void OnEnable() => UpdateEvent += OnUpdate;

        private void OnDisable() => UpdateEvent -= OnUpdate;

        protected virtual void OnUpdate()
        {
            /// <summary>
            /// This is a empty update class. This is for Subclasses update event
            /// </summary>
        }
        protected void Move(Transform gameObject, Vector3 movementData) => gameObject.Translate(movementData * _moveSpeed, Space.World);

        protected void CameraMovement(Transform gameObject, Vector3 movementData, float smoothTime) 
            => gameObject.position = Vector3.Lerp(gameObject.position, movementData, smoothTime);
    }
}
