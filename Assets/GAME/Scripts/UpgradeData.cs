using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    public float PricePerUpgrade;

    public float healthMultiplier;
    public float healthLevel;

    public float damageMultiplier;
    public float damageLevel;
}
