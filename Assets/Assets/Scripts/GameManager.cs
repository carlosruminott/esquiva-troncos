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

    [SerializeField] GameObject uiDocument;

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

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        uiDocument.SetActive(false);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        uiDocument.SetActive(true);
    }
}
