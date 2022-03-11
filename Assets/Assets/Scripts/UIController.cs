using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{

    public Button buttonResume, buttonQuit;


    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        buttonResume = root.Q<Button>("ButtonResume");
        buttonResume.clicked += ButtonResume;

        buttonQuit = root.Q<Button>("ButtonExit");
        buttonQuit.clicked += ButtonQuit;
    }

    void ButtonResume()
    {
        //Debug.Log("Pressed");
        GameManager.instance.Resume();
    }

    void ButtonQuit()
    {
        //Debug.Log("Pressed");
        GameManager.instance.QuitGame();
    }
}
