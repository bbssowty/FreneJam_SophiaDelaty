using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyData", menuName = "Scriptable Objects/CurrencyData")]
public class CurrencyData : ScriptableObject
{
    public int lCurrency;
    public int rCurrency;

    public float addCurrencyTimer = 1f;
}
