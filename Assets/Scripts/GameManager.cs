using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public PlayerAmount Amount;

    public Difficulty ChosenDifficulty;

    public static event Action<GameState> OnGameStateChanged;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateGameState(GameState.Running);
    }

    private void Update()
    {
        Pause();
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Running:
                HandleRunning();
                break;
            case GameState.PauseMenu:
                HandlePauseMenu();
                break;
            case GameState.Finished:
                HandleFinished();
                break;
            case GameState.Quit:
                HandleQuit();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleQuit()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    private void HandleFinished()
    {
        Time.timeScale = 0f;
    }
    private void HandlePauseMenu()
    {
        Time.timeScale = 0f;
    }

    private void HandleRunning()
    {
        Time.timeScale = 1f;
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && State == GameState.Running)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.PauseMenu);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && State == GameState.PauseMenu)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Running);
        }
    }

    public void updatePlayerAmount(PlayerAmount amount)
    {
        Amount = amount;

        switch (amount)
        {
            case PlayerAmount.Singleplayer:
                break;
            case PlayerAmount.Multiplayer:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(amount), amount, null);
        }
    }

    public void updateDifficulty(Difficulty difficulty)
    {
        ChosenDifficulty = difficulty;

        switch (difficulty)
        {
            case Difficulty.Easy:
                break;
            case Difficulty.Medium:
                break;
            case Difficulty.Hard:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null);
        }

    }
    public enum PlayerAmount
    {
        Singleplayer,
        Multiplayer
    }

    public enum GameState
    {
        Running,
        PauseMenu,
        Finished,
        Quit
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}
