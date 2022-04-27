using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int playerLife = 3;

    [SerializeField] GameObject[] carVisualState = new GameObject[2];

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
        UIPlayerPanel.instance.lifeLeftNumber.text = playerLife.ToString();
    }

    public void GetDamage(int damage)
    {
        playerLife -= damage;
        carVisualState[1].SetActive(false);
        carVisualState[2].SetActive(false);
        carVisualState[3].SetActive(false);
        carVisualState[playerLife].SetActive(true);
        UIPlayerPanel.instance.lifeLeftNumber.text = playerLife.ToString();
        if (playerLife == 0)
        {
            Instantiate(explotion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            //uiGameOverScreen.SetActive(true);
            //ShowGameOverScreen();
        }
    }

    public void ShowGameOverScreen()
    {
        uiGameOverScreen.SetActive(true);
    }
}
