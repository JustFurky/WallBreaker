
public interface IWall
{
    int Heal { get; }
    int Level { get; }
    int Experience { get; }
    public void Initialize();
    public void SetUI();
    public WallData GetWallData();
    public bool TakeDamage(int Damage);
}
