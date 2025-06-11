using System.Collections;
using TMPro;
using UnityEngine;

public class Conduit : MonoBehaviour
{
    public ConduitStats conduitStats;
    public GameObject conduitUser;
    public int attack;
    public int manaRegen;
    public int offenseCost;
    public int defenseCost;
    public int supportCost;

    void Start()
    {
        conduitUser = gameObject;
        attack = conduitStats.attack;
        manaRegen = conduitStats.manaRegen;
        offenseCost = conduitStats.offenseCost;
        defenseCost = conduitStats.defenseCost;
        supportCost = conduitStats.supportCost;
    }
}
