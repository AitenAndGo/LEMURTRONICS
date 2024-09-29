using UnityEngine;

public class LedMainManager : MonoBehaviour
{
    public void ChechWin()
    {
        LED[] leds = FindObjectsOfType<LED>();
        Debug.Log(leds.Length);
        // Iteruj przez ka¿dy obiekt LED w tablicy i wywo³aj metodê UpdateVisuals
        foreach (LED led in leds)
        {
            bool state = led.getState();
            if (state == false)
            {
                return;
            }
        }

        FindObjectOfType<MiniGameManager>().winScreen("MINIGAME-LEDY");
    }
}
