using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start, Game, Victory
}
public class GameManager : MonoBehaviour
{
    public static event Action<GameState> OnGameStateChanged;
    private GameState _gameState;
    public static GameManager instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
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
                    break;
                default:
                    break;
            }
            OnGameStateChanged?.Invoke(_gameState);
        }
    }
    void Start()
    {
        State = GameState.Start;
    }

    // Update is called once per frame
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
}
