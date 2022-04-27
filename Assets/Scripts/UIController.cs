using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{

    public Button buttonResume, buttonPlayAgain, buttonQuit;


    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        buttonResume = root.Q<Button>("ButtonResume");
        buttonResume.clicked += ButtonResume;

        buttonPlayAgain = root.Q<Button>("ButtonPlayAgain");
        buttonPlayAgain.clicked += ButtonPlayAgain;

        buttonQuit = root.Q<Button>("ButtonExit");
        buttonQuit.clicked += ButtonQuit;
    }

    private void OnDisable()
    {
        buttonPlayAgain.clicked -= ButtonPlayAgain;
        buttonResume.clicked -= ButtonResume;
        buttonQuit.clicked -= ButtonQuit;
    }

    void ButtonPlayAgain()
    {
        Debug.Log("Pressed");
        GameManager.instance.PlayAgain();
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
