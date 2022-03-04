using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gamePause = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /*private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("press escape");
            gamePause = gamePause ? false : true;
        }
    }*/
}
