using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LocalizationSelect : MonoBehaviour
{

    public Button buttonEn, buttonEs;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        buttonEn = root.Q<Button>("ButtonEn");
        buttonEn.clicked += SetEn;

        buttonEs = root.Q<Button>("ButtonEs");
        buttonEs.clicked += SetEs;
    }

    private void SetEn()
    {
        PlayerPrefs.SetInt("Locale", 0);
        SceneManager.LoadScene("Level 1");
    }

    private void SetEs()
    {
        PlayerPrefs.SetInt("Locale", 1);
        SceneManager.LoadScene("Level 1");
    }
}
