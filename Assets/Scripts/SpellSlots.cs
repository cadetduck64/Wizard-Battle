using UnityEngine;

public class SpellSlots : MonoBehaviour
{

    public Spells offenseSpell;
    public Spells defenseSpell;
    public Spells supportSpell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(offenseSpell + " " + defenseSpell + " " + supportSpell);
    }
}
