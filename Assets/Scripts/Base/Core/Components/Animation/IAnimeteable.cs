using System.Collections;

public interface IAnimeteable
{
    
    public void MovementListener(bool isMoving);
    public void AttackListener();
    public void StartRunning();
    public void StopRunning();
    public IEnumerator Punch();
}
