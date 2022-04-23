using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class Player : MonoBehaviour
{
    public float speed = 100f;
    public float impulse = 15f;

    public Rigidbody2D rb;
    public GameObject impulseFX;
    public GameObject impusleFire;
 
    private bool moveReady = true;
    private bool impulseReady = true;

    public ShakeData shakeData;

    private void Update()
    {
        CheckPlayerSpeed(HealthManager.instance.playerLife);

        bool isAxisPressed = Input.GetAxisRaw("Horizontal") != 0;

        if (impulseReady && Input.GetButtonDown("Jump") && isAxisPressed)
        {
            moveReady = false;
            impulseReady = false;
            Instantiate(impulseFX, gameObject.transform.position, gameObject.transform.rotation);
            impusleFire.SetActive(true);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Input.GetAxisRaw("Horizontal") < 0 ? 90f : -90f);
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed * impulse * Time.deltaTime;
            CameraShakerHandler.Shake(shakeData);
            StartCoroutine(StopImpulse());
            StartCoroutine(ReadyToImpusle());
            UIPlayerPanel.instance.timerIsRunning = true;
        }
    }

    void FixedUpdate()
    {
        /*if(impulseReady && Input.GetButtonDown("Jump"))
        {
            moveReady = false;
            impulseReady = false;
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed * impulse * Time.fixedDeltaTime;
            CameraShakerHandler.Shake(shakeData);
            Instantiate(impulseFX, gameObject.transform.position, gameObject.transform.rotation);
            StartCoroutine(StopImpulse());
            StartCoroutine(ReadyToImpusle());
        }*/

        if(moveReady)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed * Time.fixedDeltaTime;
        }
    }

    private void CheckPlayerSpeed(int life)
    {
        if(life == 3)
        {
            speed = 100f;
            impulse = 15f;
        }
        if (life == 2)
        {
            speed = 70f;
            impulse = 13f;
        }
        if (life == 1)
        {
            speed = 50f;
            impulse = 12f;
        }
        UIPlayerPanel.instance.speedNumber.text = speed.ToString();
    }

    IEnumerator StopImpulse()
    {
        yield return new WaitForSeconds(0.2f);
        moveReady = true;
        rb.velocity = Vector2.zero;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        impusleFire.SetActive(false);
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
