using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 100f;
    public float impulse = 10f;

    public Rigidbody2D rb;

    private bool moveReady = true;
    private bool impulseReady = true;


    void FixedUpdate()
    {
        if(impulseReady && Input.GetButtonDown("Jump"))
        {
            moveReady = false;
            impulseReady = false;
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed * impulse * Time.fixedDeltaTime;
            StartCoroutine(StopImpulse());
            StartCoroutine(ReadyToImpusle());
        }

        if(moveReady)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed * Time.fixedDeltaTime;
        }
    }

    IEnumerator StopImpulse()
    {
        yield return new WaitForSeconds(0.2f);
        moveReady = true;
        rb.velocity = Vector2.zero;
        Debug.Log("stop impulse");
    }

    IEnumerator ReadyToImpusle()
    {
        yield return new WaitForSeconds(5);
        impulseReady = true;
        Debug.Log("ready to impulse");
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Tronco"))
    //    {
    //        //Debug.Log("hit");
    //        Destroy(gameObject);
    //    }
        /*if (collision.CompareTag("Limit"))
        {
            Debug.Log("limite");
            //rb.velocity = Vector2.zero;
            if(!moveReady)
            {
                Destroy(gameObject);
            }
        }*/
    //}
}
