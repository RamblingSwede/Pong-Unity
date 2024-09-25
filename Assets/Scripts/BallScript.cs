using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D body;

    public SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject AI;

    private bool roundStart;

    private float topSpeed;

    private float RespawnTimer = 1f;


        // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.ChosenDifficulty == GameManager.Difficulty.Easy)
        {
            topSpeed = 10f;
        }
        else if (GameManager.Instance.ChosenDifficulty == GameManager.Difficulty.Medium)
        {
            topSpeed = 13f;
        }
        else if (GameManager.Instance.ChosenDifficulty == GameManager.Difficulty.Hard)
        {
            topSpeed = 15f;
        }
        roundStart = true;
        gameObject.transform.position = new Vector3(0f, StartingPoint(-4, 4f), 0f);

    }

    private void FixedUpdate()
    {
        if (roundStart)
        {
            body.velocity = RandomVector();
            roundStart = false;
        }
        else if (!roundStart && spriteRenderer.enabled == true)
        {
            float newSpeedX = Mathf.Clamp(body.velocity.x, -topSpeed, topSpeed);
            float newSpeedY = Mathf.Clamp(body.velocity.y, -topSpeed, topSpeed);
            body.velocity = new Vector2(newSpeedX, newSpeedY);
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }

        if (spriteRenderer.enabled == false)
        {
            RespawnBall();
        }
        OutofBounds();
    }
    void RespawnBall()
    {
        if (RespawnTimer > 0)
        {
            RespawnTimer -= Time.deltaTime;
        }
        else if (RespawnTimer <= 0)
        {
            spriteRenderer.enabled = true;
            roundStart = true;
            RespawnTimer = 1f;
            SoundManager.Instance.ScoreUpSound();
        }
    }

    private float StartingPoint(float min, float max)
    {
        float spawnPoint = Random.Range(min, max);
        return spawnPoint;
    }
    private Vector2 RandomVector()
    {
        float x;
        float y;

        if (Random.value < 0.5f)
        {
            y = -4f;
        }
        else
        {
            y = 4f;
        }

        if (Random.value < 0.5f)
        {
            x = -5f;
        }
        else
        {
            x = 5f;
        }

        return new Vector2(x, y);

    }

    void OutofBounds()
    {
        if (body.transform.position.y > 6 || body.transform.position.y < -6 || body.transform.position.x > 9.3 || body.transform.position.x < -9.3 )
        {
            if (body.transform.position.x > 0)
            {
                UIManager.Instance.ScoreUp("Right");
            } 
            else if (body.transform.position.x < 0)
            {
                UIManager.Instance.ScoreUp("Left");
            }

            UIManager.Instance.UpdateScoreUI();
            spriteRenderer.enabled = false;
            gameObject.transform.position = new Vector3(0f, StartingPoint(-4, 4f), 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player1 || collision.gameObject == player2 || collision.gameObject == AI)
        {
            SoundManager.Instance.racketBounceSound();
        }
        else
        {
            SoundManager.Instance.wallBounceSound();
        }
    }
}
