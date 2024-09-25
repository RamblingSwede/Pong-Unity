using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _PauseMenu;
    [SerializeField] private GameObject _RestartMenu;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameManager.GameState state)
    {
        _PauseMenu.SetActive(state == GameManager.GameState.PauseMenu);
        _RestartMenu.SetActive(state == GameManager.GameState.Finished);
    }
}
