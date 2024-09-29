//using UnityEngine;
//using UnityEngine.UI;

//public class SoundAdjuster : MonoBehaviour
//{
//    public Slider leftEarSlider;  // Suwak dla lewego ucha
//    public Slider rightEarSlider; // Suwak dla prawego ucha

//    public AudioSource leftAudioSource;  // èrÛd≥o düwiÍku dla lewego ucha
//    public AudioSource rightAudioSource; // èrÛd≥o düwiÍku dla prawego ucha

//    public AudioLowPassFilter leftEarFilter;  // Filtr LowPass dla lewego ucha
//    public AudioLowPassFilter rightEarFilter; // Filtr LowPass dla prawego ucha

//    public Text winText; // Tekst zwyciÍstwa

//    public float maxFrequency = 22000f;  // Maksymalna czÍstotliwoúÊ (czysty düwiÍk)
//    public float minFrequency = 500f;    // Minimalna czÍstotliwoúÊ (zniekszta≥cony düwiÍk)
//    public float tolerance = 10f;        // Margines b≥Ídu

//    private float targetLeftValue;  // Docelowa wartoúÊ dla lewego ucha
//    private float targetRightValue; // Docelowa wartoúÊ dla prawego ucha

//    private bool gameEnded = false;

//    void Start()
//    {
//        // Losowanie docelowych wartoúci suwakÛw
//        targetLeftValue = Random.Range(leftEarSlider.minValue, leftEarSlider.maxValue);
//        targetRightValue = Random.Range(rightEarSlider.minValue, rightEarSlider.maxValue);

//        // Ukryj tekst zwyciÍstwa
//        //winText.enabled = false;

//        // Zniekszta≥cenie düwiÍku na poczπtku
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
//        // Obliczanie odleg≥oúci od wartoúci docelowych
//        float leftDistance = Mathf.Abs(leftValue - targetLeftValue);
//        float rightDistance = Mathf.Abs(rightValue - targetRightValue);

//        // Ustawienie wartoúci cutoffFrequency w zaleønoúci od odleg≥oúci od celu
//        leftEarFilter.cutoffFrequency = Mathf.Lerp(minFrequency, maxFrequency, 1 - (leftDistance / leftEarSlider.maxValue));
//        rightEarFilter.cutoffFrequency = Mathf.Lerp(minFrequency, maxFrequency, 1 - (rightDistance / rightEarSlider.maxValue));
//    }

//    void CheckForWin()
//    {
//        // Sprawdzanie, czy oba suwaki sπ w tolerancji
//        if (Mathf.Abs(leftEarSlider.value - targetLeftValue) <= tolerance && Mathf.Abs(rightEarSlider.value - targetRightValue) <= tolerance)
//        {
//            OnWin();
//        }
//    }

//    void OnWin()
//    {
//        gameEnded = true;
//        winText.enabled = true; // Pokaø tekst zwyciÍstwa
//        leftAudioSource.Stop();
//        rightAudioSource.Stop();
//        Debug.Log("Gratulacje! Ustawi≥eú poprawnie düwiÍk!");
//    }
//}












using UnityEngine;
using UnityEngine.UI;

public class AudioAdjuster : MonoBehaviour
{
    public Slider leftEarSlider;  // Suwak dla lewego ucha
    public Slider rightEarSlider; // Suwak dla prawego ucha

    public AudioSource leftAudioSource;  // èrÛd≥o düwiÍku dla lewego ucha
    public AudioSource rightAudioSource; // èrÛd≥o düwiÍku dla prawego ucha

    public AudioSource leftNoiseSource;  // èrÛd≥o szumu dla lewego ucha
    public AudioSource rightNoiseSource; // èrÛd≥o szumu dla prawego ucha

    //public Text winText; // Tekst zwyciÍstwa

    public float tolerance = 5f;        // Margines b≥Ídu
    private float targetLeftValue;  // Docelowa wartoúÊ dla lewego ucha
    private float targetRightValue; // Docelowa wartoúÊ dla prawego ucha

    private bool gameEnded = false;

    void Start()
    {
        // Losowanie docelowych wartoúci suwakÛw
        targetLeftValue = Random.Range(leftEarSlider.minValue, leftEarSlider.maxValue);
        targetRightValue = Random.Range(rightEarSlider.minValue, rightEarSlider.maxValue);

        // Ukryj tekst zwyciÍstwa
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
        // Obliczanie odleg≥oúci od wartoúci docelowych
        float leftDistance = Mathf.Abs(leftValue - targetLeftValue);
        float rightDistance = Mathf.Abs(rightValue - targetRightValue);

        // Ustawienie poziomu szumu w zaleønoúci od odleg≥oúci od celu
        leftNoiseSource.volume = Mathf.Lerp(1, 0, 1 - (leftDistance / leftEarSlider.maxValue));
        rightNoiseSource.volume = Mathf.Lerp(1, 0, 1 - (rightDistance / rightEarSlider.maxValue));
    }

    void CheckForWin()
    {
        // Sprawdzanie, czy oba suwaki sπ w tolerancji
        if (Mathf.Abs(leftEarSlider.value - targetLeftValue) <= tolerance && Mathf.Abs(rightEarSlider.value - targetRightValue) <= tolerance)
        {
            //OnWin();
        }
    }

    void OnWin()
    {
        gameEnded = true;
        //winText.enabled = true; // Pokaø tekst zwyciÍstwa
        leftAudioSource.Stop();
        rightAudioSource.Stop();
        leftNoiseSource.Stop();
        rightNoiseSource.Stop();
        Debug.Log("Gratulacje! Ustawi≥eú poprawnie düwiÍk!");
    }
}
