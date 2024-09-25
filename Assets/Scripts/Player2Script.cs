using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Script : MonoBehaviour
{
    public Rigidbody2D body;

    [SerializeField] private float speed;
    [SerializeField] private float yInput;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.Amount == GameManager.PlayerAmount.Singleplayer)
        {
            Destroy(gameObject);
        }
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yInput = 1;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
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
