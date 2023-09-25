using UnityEngine;
using Zenject;

namespace WB.Base.Core.BaseClass.RewardBase
{
    public class RewardBase : MonoBehaviour
    {
        #region Private Values
        private DataManager dataManager;
        #endregion

        [Inject]
        private void GetManager(DataManager manager)
        {
            /// <summary>
            /// Get DataManager from DI
            /// </summary>
            dataManager = manager;
        }
        protected void CollectReward(int coin)
        {
            /// <summary>
            /// Set Coin Amount to DataManager
            /// </summary>
            dataManager.SetCoin(coin);
        }
    } 
}
