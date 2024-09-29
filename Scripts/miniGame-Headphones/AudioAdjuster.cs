//using UnityEngine;
//using UnityEngine.UI;

//public class SoundAdjuster : MonoBehaviour
//{
//    public Slider leftEarSlider;  // Suwak dla lewego ucha
//    public Slider rightEarSlider; // Suwak dla prawego ucha

//    public AudioSource leftAudioSource;  // �r�d�o d�wi�ku dla lewego ucha
//    public AudioSource rightAudioSource; // �r�d�o d�wi�ku dla prawego ucha

//    public AudioLowPassFilter leftEarFilter;  // Filtr LowPass dla lewego ucha
//    public AudioLowPassFilter rightEarFilter; // Filtr LowPass dla prawego ucha

//    public Text winText; // Tekst zwyci�stwa

//    public float maxFrequency = 22000f;  // Maksymalna cz�stotliwo�� (czysty d�wi�k)
//    public float minFrequency = 500f;    // Minimalna cz�stotliwo�� (zniekszta�cony d�wi�k)
//    public float tolerance = 10f;        // Margines b��du

//    private float targetLeftValue;  // Docelowa warto�� dla lewego ucha
//    private float targetRightValue; // Docelowa warto�� dla prawego ucha

//    private bool gameEnded = false;

//    void Start()
//    {
//        // Losowanie docelowych warto�ci suwak�w
//        targetLeftValue = Random.Range(leftEarSlider.minValue, leftEarSlider.maxValue);
//        targetRightValue = Random.Range(rightEarSlider.minValue, rightEarSlider.maxValue);

//        // Ukryj tekst zwyci�stwa
//        //winText.enabled = false;

//        // Zniekszta�cenie d�wi�ku na pocz�tku
//        leftEarFilter.cutoffFrequency = minFrequency;
//        rightEarFilter.cutoffFrequency = minFrequency;

//        // Odtwarzanie muzyki
//        //leftAudioSource.Play();
//        rightAudioSource.Play();
//    }

//    void Update()
//    {
//        if (!gameEnded)
//        {
//            AdjustSound(leftEarSlider.value, rightEarSlider.value);
//            //CheckForWin();
//        }
//    }

//    void AdjustSound(float leftValue, float rightValue)
//    {
//        // Obliczanie odleg�o�ci od warto�ci docelowych
//        float leftDistance = Mathf.Abs(leftValue - targetLeftValue);
//        float rightDistance = Mathf.Abs(rightValue - targetRightValue);

//        // Ustawienie warto�ci cutoffFrequency w zale�no�ci od odleg�o�ci od celu
//        leftEarFilter.cutoffFrequency = Mathf.Lerp(minFrequency, maxFrequency, 1 - (leftDistance / leftEarSlider.maxValue));
//        rightEarFilter.cutoffFrequency = Mathf.Lerp(minFrequency, maxFrequency, 1 - (rightDistance / rightEarSlider.maxValue));
//    }

//    void CheckForWin()
//    {
//        // Sprawdzanie, czy oba suwaki s� w tolerancji
//        if (Mathf.Abs(leftEarSlider.value - targetLeftValue) <= tolerance && Mathf.Abs(rightEarSlider.value - targetRightValue) <= tolerance)
//        {
//            OnWin();
//        }
//    }

//    void OnWin()
//    {
//        gameEnded = true;
//        winText.enabled = true; // Poka� tekst zwyci�stwa
//        leftAudioSource.Stop();
//        rightAudioSource.Stop();
//        Debug.Log("Gratulacje! Ustawi�e� poprawnie d�wi�k!");
//    }
//}












using UnityEngine;
using UnityEngine.UI;

public class AudioAdjuster : MonoBehaviour
{
    public Slider leftEarSlider;  // Suwak dla lewego ucha
    public Slider rightEarSlider; // Suwak dla prawego ucha

    public AudioSource leftAudioSource;  // �r�d�o d�wi�ku dla lewego ucha
    public AudioSource rightAudioSource; // �r�d�o d�wi�ku dla prawego ucha

    public AudioSource leftNoiseSource;  // �r�d�o szumu dla lewego ucha
    public AudioSource rightNoiseSource; // �r�d�o szumu dla prawego ucha

    //public Text winText; // Tekst zwyci�stwa

    public float tolerance = 5f;        // Margines b��du
    private float targetLeftValue;  // Docelowa warto�� dla lewego ucha
    private float targetRightValue; // Docelowa warto�� dla prawego ucha

    private bool gameEnded = false;

    void Start()
    {
        // Losowanie docelowych warto�ci suwak�w
        targetLeftValue = Random.Range(leftEarSlider.minValue, leftEarSlider.maxValue);
        targetRightValue = Random.Range(rightEarSlider.minValue, rightEarSlider.maxValue);

        // Ukryj tekst zwyci�stwa
        //winText.enabled = false;

        // Odtwarzanie muzyki i szumu
        leftAudioSource.Play();
        rightAudioSource.Play();
        leftNoiseSource.Play();
        rightNoiseSource.Play();
    }

    void Update()
    {
        if (!gameEnded)
        {
            AdjustSound(leftEarSlider.value, rightEarSlider.value);
            //CheckForWin();
        }
    }

    void AdjustSound(float leftValue, float rightValue)
    {
        // Obliczanie odleg�o�ci od warto�ci docelowych
        float leftDistance = Mathf.Abs(leftValue - targetLeftValue);
        float rightDistance = Mathf.Abs(rightValue - targetRightValue);

        // Ustawienie poziomu szumu w zale�no�ci od odleg�o�ci od celu
        leftNoiseSource.volume = Mathf.Lerp(1, 0, 1 - (leftDistance / leftEarSlider.maxValue));
        rightNoiseSource.volume = Mathf.Lerp(1, 0, 1 - (rightDistance / rightEarSlider.maxValue));
    }

    void CheckForWin()
    {
        // Sprawdzanie, czy oba suwaki s� w tolerancji
        if (Mathf.Abs(leftEarSlider.value - targetLeftValue) <= tolerance && Mathf.Abs(rightEarSlider.value - targetRightValue) <= tolerance)
        {
            //OnWin();
        }
    }

    void OnWin()
    {
        gameEnded = true;
        //winText.enabled = true; // Poka� tekst zwyci�stwa
        leftAudioSource.Stop();
        rightAudioSource.Stop();
        leftNoiseSource.Stop();
        rightNoiseSource.Stop();
        Debug.Log("Gratulacje! Ustawi�e� poprawnie d�wi�k!");
    }
}
