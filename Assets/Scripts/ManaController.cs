using UnityEngine;
using System.Collections;
using TMPro;

public class ManaController : MonoBehaviour
{
    public int maxMana = 9;
    public int currentMana;
    public float regenDelay;
    public Conduit conduit;
    public TextMeshProUGUI playerUi;
    public bool manaRegenEnabled;

    void Start()
    {
        currentMana = 0;
        manaRegenEnabled = true;
    }

    public IEnumerator RegenerateMana(GameObject gameObject, float delayTime)
    {
        manaRegenEnabled = false;
        if (gameObject.GetComponent<ManaController>().currentMana >= gameObject.GetComponent<ManaController>().maxMana)
        {
            manaRegenEnabled = true;
            yield break;
        }
        else
        {
            while (gameObject.GetComponent<ManaController>().currentMana < gameObject.GetComponent<ManaController>().maxMana)
            {
                yield return new WaitForSeconds(delayTime);
                AddMana(gameObject, false);
                manaRegenEnabled = true;
                yield break;
            }
        }
    }

    public void AddMana(GameObject gameObject, bool ignoreManaLimit)
    {
        if (gameObject.GetComponent<ManaController>().currentMana >= gameObject.GetComponent<ManaController>().maxMana && !ignoreManaLimit)
        { return; }
        else
        {
            gameObject.GetComponent<ManaController>().currentMana += 1;
        }
    }

    void Update()
    {
        if (gameObject.GetComponent<ManaController>().currentMana < gameObject.GetComponent<ManaController>().maxMana && manaRegenEnabled)
        {
            StartCoroutine(RegenerateMana(gameObject, regenDelay));}
        playerUi.text = "Mana: " + currentMana.ToString();
    }
}
