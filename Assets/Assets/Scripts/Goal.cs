using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public float speed = 100f;

    public Rigidbody2D rb;

    private bool moving = true;

    void FixedUpdate()
    {

        if (moving)
        {
            rb.velocity = new Vector2(0, -1) * speed * Time.fixedDeltaTime;
        }

        /*if (Input.GetButtonDown("Cancel"))
        {
            moving = moving ? false : true;
            if (moving == false)
            {
                rb.velocity = Vector2.zero;
            }
            Debug.Log(moving);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Finish");
        }
    }
}
