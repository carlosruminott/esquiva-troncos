using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public float speed = 100f;

    public Rigidbody2D rb;

    private bool moving = true;

    [SerializeField] GameObject uiGameOverScreen;

    void FixedUpdate()
    {

        if (moving)
        {
            rb.velocity = new Vector2(0, -1) * speed * Time.fixedDeltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Finish");
            uiGameOverScreen.SetActive(true);
            UIGameOver.instance.title.text = "You Win!!";
            //UIGameOver.instance.ShowThis();
        }
    }
}
