using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform lSpawn;
    [SerializeField] private Transform rSpawn;
    [SerializeField] private GameObject lUnitPrefab;
    [SerializeField] private GameObject rUnitPrefab;
    [SerializeField] private GameObject lTankPrefab;
    [SerializeField] private GameObject rTankPrefab;
    [SerializeField] private UnitData unitData;
    [SerializeField] private CurrencyData currencyData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) { SendUnit(true); }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { SendUnit(false); }
        if (Input.GetKeyDown(KeyCode.S)) { SendTank(true); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { SendTank(false); }
    }
    
    private void SendUnit(bool left)
    {
        if (left && currencyData.lCurrency >= unitData.unitPrice) 
        {
            currencyData.lCurrency -= unitData.unitPrice;
            GameObject obj = Instantiate(lUnitPrefab);
            obj.transform.position = lSpawn.position;
        }

        if (!left && currencyData.rCurrency >= unitData.unitPrice) 
        {
            currencyData.rCurrency -= unitData.unitPrice;
            GameObject obj = Instantiate(rUnitPrefab);
            obj.transform.position = rSpawn.position;
        }
    }

    private void SendTank(bool left)
    {
        if (left && currencyData.lCurrency >= unitData.tankPrice)
        {
            currencyData.lCurrency -= unitData.tankPrice;
            GameObject obj = Instantiate(lTankPrefab);
            obj.transform.position = lSpawn.position;
        }

        if (!left && currencyData.rCurrency >= unitData.unitPrice)
        {
            currencyData.rCurrency -= unitData.tankPrice;
            GameObject obj = Instantiate(rTankPrefab);
            obj.transform.position = rSpawn.position;
        }
    }
}
