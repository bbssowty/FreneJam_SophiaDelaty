using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI Player1Health;
    [SerializeField] private TextMeshProUGUI Player2Health;
    [SerializeField] private TextMeshProUGUI Player1Level;
    [SerializeField] private TextMeshProUGUI Player2Level;
    [SerializeField] private TextMeshProUGUI Player1Gold;
    [SerializeField] private TextMeshProUGUI Player2Gold;
    [Space(10)]
    [SerializeField] private PlayerData player1Data;
    [SerializeField] private PlayerData player2Data;
    [SerializeField] private UpgradeData player1Level;
    [SerializeField] private UpgradeData player2Level;

    private void Update()
    {
        Player1Health.text = $"HP: {player1Data.currentHP}";
        Player2Health.text = $"HP: {player2Data.currentHP}";

        Player1Level.text = $"Level: {player1Level.healthLevel}";
        Player2Level.text = $"Level: {player2Level.healthLevel}";

        Player1Gold.text = $"Gold: {player1Data.currentCurrency}";
        Player2Gold.text = $"Gold: {player2Data.currentCurrency}";
    }
}