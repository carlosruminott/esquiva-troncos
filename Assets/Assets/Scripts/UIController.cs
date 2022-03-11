using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{

    public Button button;


    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        button = root.Q<Button>("ButtonResume");
        button.clicked += ButtonPressed;
    }

    void ButtonPressed()
    {
        //Debug.Log("Pressed");
        GameManager.instance.Resume();
    }
}
