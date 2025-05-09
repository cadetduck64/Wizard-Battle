using UnityEngine;

[CreateAssetMenu(fileName = "TilemapInfo", menuName = "Scriptable Objects/TilemapInfo")]
public class TilemapInfo : ScriptableObject
{
    public string areaName;
    public int elevation;
    public bool damaging;
    public bool friendly;
    public bool hostile;
    public float speedMultiplyer;
}
