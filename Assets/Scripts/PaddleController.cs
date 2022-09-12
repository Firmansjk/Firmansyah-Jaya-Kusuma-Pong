using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;
    private Vector3 originalSize;
    private float originalSpeed;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        MoveObject(GetInput());
    }

    public void ActivatePUEnlarge(float paddleSize)
    {
        originalSize = transform.localScale;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, paddleSize, 1));  //mengalikan 2 Vector3
        Invoke("DeactivatePUEnlarge", 5);   //manggil method dalam beberapa waktu kedepan
    }

    public void DeactivatePUEnlarge()
    {
        transform.localScale = originalSize;
    }

    public void ActivatePUQuickness(float paddleSpeed)
    {
        originalSpeed = 5;
        speed *= paddleSpeed;
        Invoke("DeactivatePUQuickness", 5);
    }

    public void DeactivatePUQuickness()
    {
        speed = originalSpeed;
    }

    private Vector2 GetInput()
    {        
        if (Input.GetKey(upKey))
        {
            return Vector3.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector3.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("TEST: " + movement);
        //transform.Translate(movement * Time.deltaTime);
        rig.velocity = movement;
    }
}
