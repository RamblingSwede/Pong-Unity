using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button _1Player;
    [SerializeField] Button _2Players;
    [SerializeField] Button _Quit;

    // Start is called before the first frame update
    void Start()
    {
        _1Player.onClick.AddListener(Start1Player);
        _2Players.onClick.AddListener(Start2Player);
        _Quit.onClick.AddListener(Quit);
    }


    private void Start1Player()
    {
        GameManager.Instance.updatePlayerAmount(GameManager.PlayerAmount.Singleplayer);
        ScenesManager.Instance.LoadChooseDifficulty();
    }

    private void Start2Player()
    {
        GameManager.Instance.updatePlayerAmount(GameManager.PlayerAmount.Multiplayer);
        ScenesManager.Instance.LoadNewMultiplayerGame();
    }

    private void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
