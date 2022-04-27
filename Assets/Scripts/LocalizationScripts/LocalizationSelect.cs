using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class LocalizationSelect : MonoBehaviour
{

    public Button buttonEn, buttonEs;

    private void OnEnable()
    {
        //si existe idioma elegido, saltea el menu de elección de idioma
        /*int l = PlayerPrefs.GetInt("Locale");
        if (l == 0 || l == 1)
        {
            SceneManager.LoadScene("Level 1");
        }*/

        var root = GetComponent<UIDocument>().rootVisualElement;

        buttonEn = root.Q<Button>("ButtonEn");
        buttonEn.clicked += SetEn;

        buttonEs = root.Q<Button>("ButtonEs");
        buttonEs.clicked += SetEs;
    }

    private void OnDisable()
    {
        buttonEn.clicked -= SetEn;
        buttonEs.clicked -= SetEs;
    }

    private void SetEn()
    {
        PlayerPrefs.SetInt("Locale", 0);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        SceneManager.LoadScene("Level 1");
    }

    private void SetEs()
    {
        PlayerPrefs.SetInt("Locale", 1);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        SceneManager.LoadScene("Level 1");
    }
}
