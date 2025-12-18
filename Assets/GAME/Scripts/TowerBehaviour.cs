using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private PlayerData ownerData;
    [SerializeField] private CurrentPlayer owner;

    public CurrentPlayer GetOwner() => owner;

    public void TakeDamage(float ammount)
    {
        ownerData.currentHP -= (int)ammount;

        if(ownerData.currentHP <= 0)
        {
            Debug.Log("Game Over for " + ownerData.name);
        }
    }
}
