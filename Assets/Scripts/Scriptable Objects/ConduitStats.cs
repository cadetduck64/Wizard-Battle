using UnityEngine;

[CreateAssetMenu(fileName = "Staff", menuName = "Scriptable Objects/Staff")]
public class ConduitStats : ScriptableObject
{
    public int attack;
    public int manaRegen;
    public int offenseCost;
    public int defenseCost;
    public int supportCost;
}
