using UnityEngine;
using UnityEngine.Events;

public class TowerBehaviour : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private PlayerData ownerData;
    [SerializeField] private CurrentPlayer owner;

    public UnityEvent endGame;

    public CurrentPlayer GetOwner() => owner;

    public void TakeDamage(float ammount)
    {
        ownerData.currentHP -= (int)ammount;

        if(ownerData.currentHP <= 0)
        {
            endGame.Invoke();
        }
    }
}
