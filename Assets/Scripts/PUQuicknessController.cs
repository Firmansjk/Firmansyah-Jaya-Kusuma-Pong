using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUQuicknessController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;

    private float paddleSpeed = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            //paddleKiri.GetComponent<PaddleController>().ActivatePUEnlarge(paddleSize);
            ball.GetComponent<BallController>().ActivatePUQuickness(paddleSpeed);
            manager.RemovePowerUp(gameObject);
        }
    }
}
