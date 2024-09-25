using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI leftScoreText;
    [SerializeField] private TextMeshProUGUI rightScoreText;
    [SerializeField] private TextMeshProUGUI winnerText;

    private float leftScore = 0f;
    private float rightScore = 0f;

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

    // Start is called before the first frame update
    void Start()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    public void ScoreUp(string Side)
    {
        if (Side == "Left")
        {
            rightScore += 1;
        } else if (Side == "Right")
        {
            leftScore += 1;
        }
    }

    public void UpdateScoreUI()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();

        if (leftScore == 11 || rightScore == 11)
        {
            if (leftScore == 11)
            {
                winnerText.text = "Player 1 Wins!";
                winnerText.GetComponent<TextMeshProUGUI>().enabled = true;
            }
            else if (rightScore == 11)
            {
                winnerText.text = "Player 2 Wins!";
                winnerText.GetComponent<TextMeshProUGUI>().enabled = true;
            }

            GameManager.Instance.UpdateGameState(GameManager.GameState.Finished);
        }
    }
}