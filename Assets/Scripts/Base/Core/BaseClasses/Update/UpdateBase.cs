using System;
using UnityEngine;

namespace WB.Base.Core.BaseClass.UpdateBase
{
    public class UpdateBase : MonoBehaviour
    {
        public static event Action UpdateEvent;
        /// <summary>
        /// Update event for all managers
        /// If Managers Subscribe this static action they can call update
        /// </summary>
        
        public void UpdateFunc() => UpdateEvent?.Invoke();

        private void Update() => UpdateFunc();
    }
}
