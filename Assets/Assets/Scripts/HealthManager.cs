using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int playerLife = 3;

    public GameObject explotion;

    [SerializeField] GameObject uiGameOverScreen;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        UIPlayerPanel.instance.lifeLeft.text = playerLife.ToString() + " Life left";
    }

    public void GetDamage(int damage)
    {
        playerLife -= damage;
        UIPlayerPanel.instance.lifeLeft.text = playerLife.ToString() + " Life left";
        if (playerLife == 0)
        {
            Destroy(gameObject);
            Instantiate(explotion, gameObject.transform.position, gameObject.transform.rotation);
            //uiGameOverScreen.SetActive(true);
            //ShowGameOverScreen();
        }
    }

    public void ShowGameOverScreen()
    {
        uiGameOverScreen.SetActive(true);
    }
}
