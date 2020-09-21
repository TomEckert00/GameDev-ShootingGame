using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameActive;
    private SpawnManager spawnManager;
    public TextMeshProUGUI pointsUI;
    public TextMeshProUGUI playerHealthUI;
    private PlayerController playerController;

    public GameObject screenStart;
    public GameObject screenIngame;
    public GameObject screenGameOver;
    public TextMeshProUGUI gameOverPoints;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void StartGame()
    {
        screenStart.SetActive(false);
        screenIngame.SetActive(true);
        spawnManager.StartGame();
    }

    public void EndGame()
    {
        spawnManager.SetGameInactiv();
        screenIngame.SetActive(false);
        gameOverPoints.SetText("Punktestand: " + playerController.points);
        screenGameOver.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetHealthUI(int playerHealth) => playerHealthUI.SetText("Gesundheit: " + playerHealth);
    public void SetPointUI(int points) => pointsUI.SetText("Punktestand:" + points);
}