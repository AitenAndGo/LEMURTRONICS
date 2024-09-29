using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LED : MonoBehaviour
{
    public bool isOn; // Czy LED jest w³¹czony
    public GameObject ON;
    public GameObject OFF;

    void Start()
    {
        ON.SetActive(false);
        OFF.SetActive(true);

        // Ustawienie pocz¹tkowego stanu LEDa (czy jest w³¹czony)
        isOn = Random.value > 0.4f; // Szansa 30% na to, ¿e LED bêdzie wy³¹czony
        //UpdateLEDVisual();
    }

    // Funkcja do aktualizowania wizualizacji LEDa
    public void UpdateLEDVisual()
    {
        if (isOn)
        {
            ON.SetActive(true);  // W³¹czony LED
            OFF.SetActive(false);
        }
        else
        {
            OFF.SetActive(true); // Wy³¹czony LED
            ON.SetActive(false);
        }
    }

    public void LED_OFF()
    {
        OFF.SetActive(true); // Wy³¹czony LED
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
