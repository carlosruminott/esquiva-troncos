using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIPlayerPanel : MonoBehaviour
{
    public static UIPlayerPanel instance;

    public Label impulseTimer;
    public Label lifeLeft;

    public float timeRemaining = 5;
    public bool timerIsRunning = false;

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

        impulseTimer = root.Q<Label>("ImpulseTimer");
        lifeLeft = root.Q<Label>("LifeLeft");
    }


    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                impulseTimer.text = Mathf.RoundToInt(timeRemaining).ToString();
            }
            else
            {
                timeRemaining = 5;
                timerIsRunning = false;
                impulseTimer.text = "Power Gas Ready!";
            }
        }
    }
}
