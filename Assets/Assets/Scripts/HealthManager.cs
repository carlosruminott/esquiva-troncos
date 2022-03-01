using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int playerLife = 3;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GetDamage(int damage)
    {
        playerLife -= damage;
        if(playerLife == 0)
        {
            Destroy(gameObject);
        }
    }
}
