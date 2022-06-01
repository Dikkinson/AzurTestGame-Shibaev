using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Start, Game, Victory
}
public class GameManager : MonoBehaviour
{
    public static event Action<GameState> OnGameStateChanged;
    private GameState _gameState;
    public static GameManager i;
    [SerializeField] private ParticleSystem firework;
    private void Awake()
    {
        if (!i)
        {
            i = this;
        }else
        {
            Destroy(gameObject);
        }
    }
    public GameState State
    { 
        get
        {
            return _gameState;
        } 
        set
        {
            _gameState = value;
            switch (_gameState)
            {
                case GameState.Start:
                    break;
                case GameState.Game:
                    break;
                case GameState.Victory:
                    firework.Play();
                    break;
                default:
                    break;
            }
            OnGameStateChanged?.Invoke(_gameState);
        }
    }
    void Update()
    {
        if (State == GameState.Start)
        {
            if (Input.GetMouseButtonDown(0))
            {
                State = GameState.Game;
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
