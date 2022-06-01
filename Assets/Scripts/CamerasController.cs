using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }
    private void GameManager_OnGameStateChanged(GameState state)
    {
        ChangeCamera(state);
    }
    private void ChangeCamera(GameState state)
    {
        foreach (var cam in cameras)
        {
            Debug.Log(cam);
            cam.SetActive(false);
        }
        cameras[(int)state].SetActive(true);
    }
}
