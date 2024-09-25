using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIChooseDifficulty : MonoBehaviour
{

    [SerializeField] Button _Easy;
    [SerializeField] Button _Medium;
    [SerializeField] Button _Hard;

    // Start is called before the first frame update
    void Start()
    {
        _Easy.onClick.AddListener(chooseEasy);
        _Medium.onClick.AddListener(chooseMedium);
        _Hard.onClick.AddListener(chooseHard);
    }

    private void chooseEasy()
    {
        GameManager.Instance.updateDifficulty(GameManager.Difficulty.Easy);
        ScenesManager.Instance.LoadNewGame();
    }

    private void chooseMedium()
    {
        GameManager.Instance.updateDifficulty(GameManager.Difficulty.Medium);
        ScenesManager.Instance.LoadNewGame();
    }

    private void chooseHard()
    {
        GameManager.Instance.updateDifficulty(GameManager.Difficulty.Hard);
        ScenesManager.Instance.LoadNewGame();
    }
}
