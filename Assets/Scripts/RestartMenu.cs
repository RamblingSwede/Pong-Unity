using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] Button _Yes;
    [SerializeField] Button _No;

    // Start is called before the first frame update
    void Start()
    {
        _Yes.onClick.AddListener(chooseYes);
        _No.onClick.AddListener(chooseNo);
    }

    private void chooseYes()
    {
        ScenesManager.Instance.LoadNewGame();
    }

    private void chooseNo()
    { 
        ScenesManager.Instance.LoadMainMenu();
    }
}
