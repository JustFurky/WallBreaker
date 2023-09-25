using UnityEngine;
using WB.Base.Core.BaseClass.RewardBase;

namespace WB.Base.Core.Components.RewardPointComponent
{
    using WB.Base.Core.Components.TriggerComponent;
    public class RewardPointComponent : RewardBase
    {
        #region Variable
        [SerializeField] private int _coinAmount;
        #endregion

        /// <summary>
        /// This script keeps the list of walls that have children and if the player breaks all the walls and collects the reward the walls will respawn.
        /// </summary>

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TriggerComponent>())
                CollectEvent(GetComponentInParent<WallHolder>(), other.gameObject.transform);
        }

        private void CollectEvent(WallHolder wallHolder, Transform transform)
        {
            wallHolder.ReLoad(transform);
            CollectReward(_coinAmount);
        }
    }
}
