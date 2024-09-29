using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LED : MonoBehaviour
{
    public bool isOn; // Czy LED jest w��czony
    public GameObject ON;
    public GameObject OFF;

    void Start()
    {
        ON.SetActive(false);
        OFF.SetActive(true);

        // Ustawienie pocz�tkowego stanu LEDa (czy jest w��czony)
        isOn = Random.value > 0.4f; // Szansa 30% na to, �e LED b�dzie wy��czony
        //UpdateLEDVisual();
    }

    // Funkcja do aktualizowania wizualizacji LEDa
    public void UpdateLEDVisual()
    {
        if (isOn)
        {
            ON.SetActive(true);  // W��czony LED
            OFF.SetActive(false);
        }
        else
        {
            OFF.SetActive(true); // Wy��czony LED
            ON.SetActive(false);
        }
    }

    public void LED_OFF()
    {
        OFF.SetActive(true); // Wy��czony LED
        ON.SetActive(false);
    }

    public bool getState()
    {
        return isOn;
    }
    public void changeState()
    {
        if (!FindObjectOfType<PowerButton>().Power)
        {
            isOn = !isOn;
        }
    }
}
