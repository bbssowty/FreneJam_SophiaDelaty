using System.Collections;
using UnityEngine;

public enum CurrentPlayer
{
    Player1,
    Player2
}

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float delay = 1f;
    [SerializeField] private int defaultCurrency = 20;
    [SerializeField] private int defaultHP = 500;

    [Header("References")]
    [SerializeField] private PlayerData player1Data;
    [SerializeField] private PlayerData player2Data;

    [SerializeField] private UpgradeData player1UpgradeData;
    [SerializeField] private UpgradeData player2UpgradeData;

    void Start()
    {
        StartCoroutine(AddCurrency());

        player1Data.currentCurrency = defaultCurrency;
        player1Data.currentHP = defaultHP;

        player2Data.currentCurrency = defaultCurrency;
        player2Data.currentHP = defaultHP;

        player1UpgradeData.damageLevel = 1;
        player1UpgradeData.healthLevel = 1;

        player2UpgradeData.damageLevel = 1;
        player2UpgradeData.healthLevel = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) UpgradePlayer(CurrentPlayer.Player1, player1UpgradeData);
        if (Input.GetKeyDown(KeyCode.UpArrow)) UpgradePlayer(CurrentPlayer.Player2, player2UpgradeData);
    }

    private void UpgradePlayer(CurrentPlayer player, UpgradeData data)
    {
        if(player == CurrentPlayer.Player1)
        {
            if (player1Data.currentCurrency - data.PricePerUpgrade <= 0) return;

            player1Data.currentCurrency -= (int)data.PricePerUpgrade;
            data.damageLevel += 1;
            data.healthLevel += 1;
        }
        else
        {
            if (player2Data.currentCurrency - data.PricePerUpgrade <= 0) return;

            player2Data.currentCurrency -= (int)data.PricePerUpgrade;
            data.damageLevel += 1;
            data.healthLevel += 1;
        }
    }

    private IEnumerator AddCurrency()
    {
        player1Data.currentCurrency += 1;
        player2Data.currentCurrency += 1;

        yield return new WaitForSeconds(delay);

        StartCoroutine(AddCurrency());
    }
}