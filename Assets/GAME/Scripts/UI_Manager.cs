using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UI_Manager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI Player1Health;
    [SerializeField] private TextMeshProUGUI Player2Health;
    [SerializeField] private TextMeshProUGUI Player1Level;
    [SerializeField] private TextMeshProUGUI Player2Level;
    [SerializeField] private TextMeshProUGUI Player1Gold;
    [SerializeField] private TextMeshProUGUI Player2Gold;
    [SerializeField] private TextMeshProUGUI Winner;
    [Space(10)]
    [SerializeField] private PlayerData player1Data;
    [SerializeField] private PlayerData player2Data;
    [SerializeField] private UpgradeData player1Level;
    [SerializeField] private UpgradeData player2Level;
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private TowerBehaviour towerBehaviour;

    private void Start() 
    {
        mainMenuCanvas.SetActive(true); endGameCanvas.SetActive(false); inGameCanvas.SetActive(false);
    }

    private void Update()
    {
        Player1Health.text = $"HP: {player1Data.currentHP}";
        Player2Health.text = $"HP: {player2Data.currentHP}";

        Player1Level.text = $"Level: {player1Level.healthLevel}";
        Player2Level.text = $"Level: {player2Level.healthLevel}";

        Player1Gold.text = $"Gold: {player1Data.currentCurrency}";
        Player2Gold.text = $"Gold: {player2Data.currentCurrency}";

        Winner.text = $"WINNER: {towerBehaviour.GetOwner()}!";
    }

    public void StartGame()
    {
        mainMenuCanvas.SetActive(false); endGameCanvas.SetActive(false); inGameCanvas.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnEndGame()
    {
        mainMenuCanvas.SetActive(false); endGameCanvas.SetActive(true); inGameCanvas.SetActive(false);
        Debug.Log($"WINNER: {towerBehaviour.GetOwner()}!");
    }
}