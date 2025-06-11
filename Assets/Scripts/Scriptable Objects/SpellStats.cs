using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellStats", menuName = "Scriptable Objects/SpellStats")]
public class SpellStats : ScriptableObject
{
    public enum SpellTypes {
        Offense,
        Defense,
        Support
    }
}
