using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] Button _Continue;
    [SerializeField] Button _MainMenu;
    [SerializeField] Button _Quit;

    void Start()
    {
        _Continue.onClick.AddListener(Continue);
        _MainMenu.onClick.AddListener(ReturnToMenu);
        _Quit.onClick.AddListener(Quit);
    }
    private void Continue()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Running);
    }
    private void ReturnToMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
    }
    private void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
