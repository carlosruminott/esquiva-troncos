using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionParticleSystem : MonoBehaviour
{
    public void OnParticleSystemStopped()
    {
        Debug.Log("Stop");
        HealthManager.instance.ShowGameOverScreen();
    }
}
