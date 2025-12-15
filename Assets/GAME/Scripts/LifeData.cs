using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "LifeData", menuName = "Scriptable Objects/LifeData")]
public class LifeData : ScriptableObject
{
    public float lTowerLifeValue;
    public float lUnitLifeValue;
    public float rTowerLifeValue;
    public float rUnitLifeValue;
}
