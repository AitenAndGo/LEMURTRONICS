using UnityEngine;
using UnityEngine.UI;

public class OrderBar : MonoBehaviour
{
    public Image image;  // Referencja do paska w formie Image
    private Vector3 originalScale;  // Przechowuje oryginaln� skal� obrazu
    private float maxTime;

    void Start()
    {
        // Zapisz pocz�tkow� skal� obrazu (np. szeroko�� jako 1.0)
        originalScale = new Vector3(1f, 1f, 1f);
    }

    // Ustawia maksymalny czas i ustawia pasek na pe�n� skal�
    public void SetMaxTime(float time)
    {
        // Ustaw pe�n� skal�, gdy pasek jest pe�en
        image.transform.localScale = originalScale;
        maxTime = time;
    }

    // Aktualizuje pasek w zale�no�ci od pozosta�ego czasu
    public void SetTime(float time)
    {
        // Oblicz proporcj� w zale�no�ci od maksymalnego czasu
        float scaleX = time / maxTime;
        //Debug.Log(scaleX);

        // Ustaw now� skal� X, reszta pozostaje taka sama
        image.transform.localScale = new Vector3(scaleX * originalScale.x, originalScale.y, originalScale.z);
    }
}
