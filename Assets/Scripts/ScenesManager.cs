using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
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
    public enum Scene
    {
        MainMenu,
        ChooseDifficulty,
        Main
    } 

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Main.ToString());
    }

    public void LoadNewMultiplayerGame()
    {
        SceneManager.LoadScene(Scene.Main.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadChooseDifficulty()
    {
        SceneManager.LoadScene(Scene.ChooseDifficulty.ToString());
    }
}
