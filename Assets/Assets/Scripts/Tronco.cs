using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco : MonoBehaviour
{
    public float speed = 100f;

    public Rigidbody2D rb;

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -1) * speed * Time.fixedDeltaTime;
    }
}
