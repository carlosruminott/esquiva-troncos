using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIPlayerPanel : MonoBehaviour
{
    public static UIPlayerPanel instance;

    public Label impulseTimer;
    public Label lifeLeftText, lifeLeftNumber;
    public Label speedText, speedNumber;

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
        lifeLeftText = root.Q<Label>("LifeLeftText");
        lifeLeftNumber = root.Q<Label>("LifeLeftNumber");
        speedText = root.Q<Label>("SpeedText");
        speedNumber = root.Q<Label>("SpeedNumber");
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
                var localization = GetComponent<LocalizationUIPlayerPanel>()._currentStringTable;
                impulseTimer.text = localization["ImpulseTimerReady"].LocalizedValue;
            }
        }
    }
}
