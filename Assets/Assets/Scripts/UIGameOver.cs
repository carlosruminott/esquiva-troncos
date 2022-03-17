using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    public Button buttonPlayAgain, buttonQuit;


    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        buttonPlayAgain = root.Q<Button>("ButtonPlayAgain");
        buttonPlayAgain.clicked += ButtonPlayAgain;

        buttonQuit = root.Q<Button>("ButtonExit");
        buttonQuit.clicked += ButtonQuit;
    }

    private void OnDisable()
    {
        buttonPlayAgain.clicked -= ButtonPlayAgain;
        buttonQuit.clicked -= ButtonQuit;
    }

    void ButtonPlayAgain()
    {
        //Debug.Log("Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ButtonQuit()
    {
        //Debug.Log("Pressed");
        GameManager.instance.QuitGame();
    }
}
