using System.Collections;
using UnityEngine;
using WB.Base.Core.Components.MovementComponent;

[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(TriggerComponent))]

public class AnimationComponent : AnimationBase, IAnimeteable
{
    #region Components
    private MovementComponent _movementComponent;
    private TriggerComponent _triggerComponent;
    private Animator _animator;
    #endregion

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movementComponent = GetComponent<MovementComponent>();
        _triggerComponent = GetComponent<TriggerComponent>();
    }

    private void OnEnable()
    {
        _triggerComponent.AttackSignal += AttackListener;
        _movementComponent.MoveSignal += MovementListener;
    }

    private void OnDisable()
    {
        _triggerComponent.AttackSignal -= AttackListener;
        _movementComponent.MoveSignal -= MovementListener;
    }

    public void MovementListener(bool isMoving)
    {
        if (isMoving)
            StartRunning();
        else
            StopRunning();
    }
    public void AttackListener()
    {
        //Punch();
    }

    public void StartRunning()
    {
        SetAnimationBool(_animator, "Run", true);
    }

    public void StopRunning()
    {
        SetAnimationBool(_animator, "Run", false);
    }
    public IEnumerator Punch()
    {
    //    SetAnimationLayerWeight(_animator, 1, 1);
        yield return new WaitForSeconds(0);
    //    SetAnimationLayerWeight(_animator, 1, 0);
    }
}