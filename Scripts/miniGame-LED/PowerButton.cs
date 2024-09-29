using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    public bool isOn; // Czy LED jest w³¹czony
    public GameObject ON;
    public GameObject OFF;
    public bool Power = false; 

    // Start is called before the first frame update
    void Start()
    {
        powerOff();
    }

    public void powerOn()
    {
        LED[] leds = FindObjectsOfType<LED>();
        foreach (LED led in leds)
        {
            led.UpdateLEDVisual();
        }

        ON.SetActive(true);
        OFF.SetActive(false);
        Power = true;

        FindObjectOfType<LedMainManager>().ChechWin();
    }

    public void powerOff()
    {
        LED[] leds = FindObjectsOfType<LED>();
        Debug.Log(leds.Length);
        // Iteruj przez ka¿dy obiekt LED w tablicy i wywo³aj metodê UpdateVisuals
        foreach (LED led in leds)
        {
            led.LED_OFF();
        }

        OFF.SetActive(true);
        ON.SetActive(false);
        Power = false;
    }
}
