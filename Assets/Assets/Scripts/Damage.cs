using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class Damage : MonoBehaviour
{
    public ShakeData shakeData;
    private bool inmunity = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraShakerHandler.Shake(shakeData);
            Debug.Log(inmunity);
            if(inmunity == false)
            {
                inmunity = true;
                HealthManager.instance.GetDamage(1);
                StartCoroutine(InmunityTime());
            }
        }
    }

    private IEnumerator InmunityTime()
    {
        yield return new WaitForSeconds(5);
        inmunity = false;
        Debug.Log("chau inmunidad");
    }
}
