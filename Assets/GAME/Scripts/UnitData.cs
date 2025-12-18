using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Objects/UnitData")]
public class UnitData : ScriptableObject
{
    public int Price;

    public float Health;
    public float Speed;
    public float Damage;
    public float AttackSpeed;

    public GameObject Player1Prefab;
    public GameObject Player2Prefab;
}