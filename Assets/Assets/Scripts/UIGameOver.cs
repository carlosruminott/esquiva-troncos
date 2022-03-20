using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    public static UIGameOver instance;

    public Button buttonPlayAgain, buttonQuit;

    public Label title;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        title = root.Q<Label>("Title");

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

    /*public void ShowThis()
    {
        gameObject.SetActive(true);
    }*/
}
