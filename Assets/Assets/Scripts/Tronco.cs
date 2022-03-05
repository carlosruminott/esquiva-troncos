using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco : MonoBehaviour
{
    public float speed = 100f;

    public Rigidbody2D rb;

    private float _rotation;
    private float _angularVelocity;
    private bool moving = true;


    void FixedUpdate()
    {
        //rb.velocity = new Vector2(0, -1) * speed * Time.fixedDeltaTime;
        if (moving)
        {
            MovingDown();
        }
        /*if (Input.GetButtonUp("Cancel"))
        {
            Debug.Log("pressed");
            moving = moving ? false : true;
            if(moving == false)
            {
                StopMoving();
            }else
            {
                ResumeMoving();
            }
        }*/
    }


    public void MovingDown()
    {
        rb.velocity = new Vector2(0, -1) * speed * Time.fixedDeltaTime;
    }

    /*public void ResumeMoving()
    {
        //Debug.Log(moving);
        rb.isKinematic = false;
        rb.freezeRotation = false;
        rb.rotation = _rotation;
        rb.angularVelocity = _angularVelocity;
    }

    public void StopMoving()
    {
        //Debug.Log(moving);
        _rotation = rb.rotation;
        _angularVelocity = rb.angularVelocity;
        rb.velocity = Vector2.zero;
        rb.freezeRotation = true;
        rb.isKinematic = true;
    }*/
}
