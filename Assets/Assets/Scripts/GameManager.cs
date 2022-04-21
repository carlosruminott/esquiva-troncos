using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

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
        StartCoroutine(setLanguage());
    }

    public IEnumerator setLanguage()
    {
        // Wait for the localization system to initialize, loading Locales, preloading, etc.
        yield return LocalizationSettings.InitializationOperation;

        int i = PlayerPrefs.GetInt("Locale");

        // This part changes the language
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];
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

    public void PlayAgain()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        uiDocument.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
    }
}
