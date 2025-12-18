using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player1SpawnPoint;
    [SerializeField] private Transform player2SpawnPoint;
    [SerializeField] private PlayerData player1Data;
    [SerializeField] private PlayerData player2Data;
    [SerializeField] private UnitData goblinData;
    [SerializeField] private UnitData tankData;
    [SerializeField] private UpgradeData player1UpgradeData;
    [SerializeField] private UpgradeData player2UpgradeData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) SendUnit(CurrentPlayer.Player1, goblinData);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) SendUnit(CurrentPlayer.Player2, goblinData);

        if (Input.GetKeyDown(KeyCode.S)) SendUnit(CurrentPlayer.Player1, tankData);
        if (Input.GetKeyDown(KeyCode.DownArrow)) SendUnit(CurrentPlayer.Player2, tankData);
    }

    private void SendUnit(CurrentPlayer source, UnitData unitData)
    {
        if (source == CurrentPlayer.Player1)
        {
            if (player1Data.currentCurrency > unitData.Price)
            {
                GameObject player1Unit = Instantiate(unitData.Player1Prefab, player1SpawnPoint.position, Quaternion.identity);
                player1Unit.GetComponent<UnitBehavior>().Setup(unitData, CurrentPlayer.Player1, player1UpgradeData.healthLevel * player1UpgradeData.healthMultiplier, player1UpgradeData.damageLevel * player1UpgradeData.damageMultiplier);
                player1Data.currentCurrency -= unitData.Price;
            }
        }

        else
        {
            if (player2Data.currentCurrency > unitData.Price)
            {
                GameObject player2Unit = Instantiate(unitData.Player2Prefab, player2SpawnPoint.position, Quaternion.identity);
                player2Unit.GetComponent<UnitBehavior>().Setup(unitData, CurrentPlayer.Player2, player2UpgradeData.healthLevel * player2UpgradeData.healthMultiplier, player2UpgradeData.damageLevel * player2UpgradeData.damageMultiplier);
                player2Data.currentCurrency -= unitData.Price;
            }
        }
    }
}