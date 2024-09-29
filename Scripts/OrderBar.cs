using UnityEngine;
using UnityEngine.UI;

public class OrderBar : MonoBehaviour
{
    public Image image;  // Referencja do paska w formie Image
    private Vector3 originalScale;  // Przechowuje oryginaln¹ skalê obrazu
    private float maxTime;

    void Start()
    {
        // Zapisz pocz¹tkow¹ skalê obrazu (np. szerokoœæ jako 1.0)
        originalScale = new Vector3(1f, 1f, 1f);
    }

    // Ustawia maksymalny czas i ustawia pasek na pe³n¹ skalê
    public void SetMaxTime(float time)
    {
        // Ustaw pe³n¹ skalê, gdy pasek jest pe³en
        image.transform.localScale = originalScale;
        maxTime = time;
    }

    // Aktualizuje pasek w zale¿noœci od pozosta³ego czasu
    public void SetTime(float time)
    {
        // Oblicz proporcjê w zale¿noœci od maksymalnego czasu
        float scaleX = time / maxTime;
        //Debug.Log(scaleX);

        // Ustaw now¹ skalê X, reszta pozostaje taka sama
        image.transform.localScale = new Vector3(scaleX * originalScale.x, originalScale.y, originalScale.z);
    }
}
