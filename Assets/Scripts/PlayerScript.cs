using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody2D body;

    [SerializeField] private float speed;
    [SerializeField] private float yInput;

    private void Start()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Running);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        YMovement();
    }

    void YMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            yInput = 1;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            yInput = -1;
        }

        else
        {
            yInput = 0;
        }

        body.velocity = new Vector2(body.velocity.x, yInput * speed);
    }
}
