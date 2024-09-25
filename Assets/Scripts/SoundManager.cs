using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource wallBounce;
    public AudioSource racketBounce;
    public AudioSource scoreUp;

    public static SoundManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void ScoreUpSound() { 
        scoreUp.Play();
    }

    public void wallBounceSound()
    {
        wallBounce.Play();
    }

    public void racketBounceSound()
    {
        racketBounce.Play();
    }


}
