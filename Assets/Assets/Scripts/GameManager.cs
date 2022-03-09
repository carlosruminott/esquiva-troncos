using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //para patron observer
    public static Action GamePause;

    public static bool GameIsPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
