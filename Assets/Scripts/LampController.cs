using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public GameObject lightMask;
    public GameObject LightArea;
    private bool isOn = false;

    public bool IsOn => isOn;

    void Start()
    {
        LightArea.SetActive(false);
        lightMask.SetActive(false);
    }

    public void ToggleLamp()
    {
        
        isOn = !isOn;
        
        LightArea.SetActive(isOn);
        lightMask.SetActive(isOn);
    }
}
