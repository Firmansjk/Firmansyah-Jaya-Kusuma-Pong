using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUEnlargeController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;

    private float paddleSize = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUEnlarge(paddleSize);
            manager.RemovePowerUp(gameObject);
        }
    }
}
