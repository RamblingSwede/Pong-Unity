using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class AIScript : MonoBehaviour
{
    public Rigidbody2D body;

    public SpriteRenderer spriteRenderer;

    public GameObject ball;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.Amount == GameManager.PlayerAmount.Multiplayer)
        {
            Destroy(gameObject);
        }

        if (GameManager.Instance.ChosenDifficulty == GameManager.Difficulty.Easy)
        {
            speed = 8f;
        } 
        else if (GameManager.Instance.ChosenDifficulty == GameManager.Difficulty.Medium)
        {
            speed = 9.5f;
        } 
        else if (GameManager.Instance.ChosenDifficulty == GameManager.Difficulty.Hard)
        {
            speed = 13f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (spriteRenderer.enabled == true)
        {
            if (findBallPos().x > -3)
            {
                interceptBall();
            }
        } else
        {
            body.velocity = Vector2.zero;
        }
    }

    private Vector2 findBallPos()
    {
        Vector2 ballPos = new Vector2(ball.transform.position.x, ball.transform.position.y);
        return ballPos;
    }

    private void interceptBall()
    {
        if (findBallPos().y > body.transform.position.y + 0.1)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
        else if (findBallPos().y < body.transform.position.y - 0.1)
        {
            body.velocity = new Vector2(body.velocity.x, -speed);
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }
}
