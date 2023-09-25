using UnityEngine;
namespace WB.Base.Core.BaseClass.AnimationBase
{
    public class AnimationBase : MonoBehaviour
    {

        public void SetAnimationBool(Animator animator, string boolName, bool boolValue)
        {
            animator.SetBool(boolName, boolValue);
        }
        public void SetAnimationLayerWeight(Animator animator, int layerIndex, float weightValue)
        {
            animator.SetLayerWeight(layerIndex, weightValue);
        }
    } 
}
