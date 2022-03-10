using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        button = root.Q<Button>("Button");
        button.clicked += ButtonPressed;
    }

    void ButtonPressed()
    {
        Debug.Log("Pressed");
    }
}
