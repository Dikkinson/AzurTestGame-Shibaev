using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject victoryPanel;
    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                ChangeWindow(mainMenuPanel);
                break;
            case GameState.Game:
                ChangeWindow(gamePanel);
                break;
            case GameState.Victory:
                ChangeWindow(victoryPanel);
                break;
            default:
                break;
        }
    }
    private void ChangeWindow(GameObject window)
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);

        window.SetActive(true);
    }
}
