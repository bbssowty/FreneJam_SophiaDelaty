using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CurrencyData currencyData;
    [SerializeField] private UpgradeData upgradeData;
    [SerializeField] private LifeData lifeData;


    private bool isCurrencyTimed = true;
    void Start()
    {
        currencyData.lCurrency = 1;
        currencyData.rCurrency = 1;
        upgradeData.lAttack = 1;
        upgradeData.rAttack = 1;
        lifeData.lTowerLifeValue = 50;
        lifeData.lUnitLifeValue = 2;
        lifeData.rTowerLifeValue = 50;
        lifeData.rUnitLifeValue = 2;
    }

    
    void Update()
    {
        if (isCurrencyTimed)
        {
            StartCoroutine(AddCurrency());
        }


        if (Input.GetKeyDown(KeyCode.W)) { Upgrade(true); }
        if (Input.GetKeyDown(KeyCode.S)) { BuyUnit(true); }
        if (Input.GetKeyDown(KeyCode.D)) { SendUnit(true); }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) { Upgrade(false); }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { BuyUnit(false); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { SendUnit(false); }
    }

    private IEnumerator AddCurrency()
    {
        isCurrencyTimed = false;
        currencyData.lCurrency += 1;
        currencyData.rCurrency += 1;
        yield return new WaitForSeconds(currencyData.addCurrencyTimer);
        isCurrencyTimed = true;
    }

    private void Upgrade (bool left)
    {
        if(left == true) { upgradeData.lAttack += 0.5f; }
        if (left == false) { upgradeData.rAttack += 0.5f; }
    }

    private void BuyUnit(bool left)
    {
        if (left == true) { Debug.Log("left"); }
        if (left == false) { Debug.Log("right"); }
    }

    private void SendUnit(bool left)
    {
        if (left == true) { Debug.Log("left"); }
        if (left == false) { Debug.Log("right"); }
    }
}
