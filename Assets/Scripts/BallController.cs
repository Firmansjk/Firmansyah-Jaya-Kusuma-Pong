using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;

    private Rigidbody2D rig;
    private PaddleController lastPaddle;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    void Update()
    {
        //transform.Translate(speed * Time.deltaTime);
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 1);
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    public void ActivatePUEnlarge(float paddleSize)
    {
        lastPaddle.ActivatePUEnlarge(paddleSize);       //nge-pass tugas ke PaddleController
    }

    public void ActivatePUQuickness(float paddleSpeed)
    {
        lastPaddle.ActivatePUQuickness(paddleSpeed);    //nge-pass tugas ke PaddleController
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            lastPaddle = collision.collider.GetComponent<PaddleController>();
            //Debug.Log("PADDLE = " + collision.collider.gameObject.name);
        }
    }
}
