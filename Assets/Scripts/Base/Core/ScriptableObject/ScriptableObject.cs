using UnityEngine;

[CreateAssetMenu(fileName = "WallData", menuName = "ScriptableObjects/Data/WallData")]
public class WallData : ScriptableObject
{
    public int Heal;
    public int Experiance;
    public int Level;
    public Texture2D Texture;
}
