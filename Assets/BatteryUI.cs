using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    Slider flashLightSlider;
    Flashlight flashlight;

    private void Start()
    {
        flashLightSlider = GetComponent<Slider>();
        flashlight = FindObjectOfType<Flashlight>();
    }

    private void Update()
    {
        flashLightSlider.value = flashlight.batteryCharge;
    }
}
