using System;
using UnityEngine;
using WB.Base.Core.BaseClass.MovementBase;

namespace WB.Base.Core.Components.MovementComponent
{
    public class MovementComponent : MovementBase, IMoveable
    {
        #region Action
        public event Action<bool> MoveSignal;
        #endregion

        #region Component
        [SerializeField] private FloatingJoystick _joystick;
        #endregion

        #region Variables
        private Vector3 _joystickData;
        #endregion

        protected override void OnUpdate()
        {
            ReadInput();
        }
        public void MoveFromInput()
        {
            Move(transform, _joystickData);
        }

        public void ReadInput()
        {
            _joystickData = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical) * Time.deltaTime;
            MovementEvent();
            MoveFromInput();
            RotateFromInput();
        }

        public void RotateFromInput()
        {
            transform.LookAt(transform.position + _joystickData, Vector3.up);
        }
        private void MovementEvent()
        {
            if (_joystickData != Vector3.zero)
                MoveSignal?.Invoke(true);
            else
                MoveSignal?.Invoke(false);
        }
    }
}
