using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public float countdownTime = 10f; // Czas odliczania w sekundach
    private float currentTime;        // Aktualny czas
    public int maxPoints = 100;
    public int minigamesNumber = 3;

    public GameObject przycisk;
    public GameObject przycisk_szare;

    public GameObject screwdriver;
    public GameObject screwdriver_szare;

    public GameObject lutownica;
    public GameObject lutownica_szare;

    public GameObject rezystor;
    public GameObject rezystor_szare;

    public GameObject kabel;
    public GameObject kabel_szare;

    public int orderType;

    public OrderBar orderBar;

    // Listy przedmiot�w dla r�nych typ�w zam�wie�
    private List<string> itemsForOrderType0 = new List<string> { "button", "button", "screwdriver" };
    private List<string> itemsForOrderType1 = new List<string> { "lutownica", "rezystor", "kabel" };
    private List<string> itemsForOrderType2 = new List<string> { "kabel", "kabel", "lutownica" };

    // Lista przechowuj�ca wymagane przedmioty dla aktualnego zam�wienia
    public List<string> requiredItems = new List<string>();

    public List<GameObject> selectedItems = new List<GameObject>();
    public List<GameObject> blankItems = new List<GameObject>();

    private bool stopTimer = true;


    // Start is called before the first frame update
    void Start()
    {
        reset();
    }

    public void StopTimer()
    {
        stopTimer = true;
    }

    public void reset()
    {
        stopTimer = false;
        currentTime = countdownTime;
        orderType = Random.Range(0, minigamesNumber);

        // Ustawienie wymaganych przedmiot�w na podstawie typu zam�wienia
        SetOrderItems(orderType);


        orderBar.SetMaxTime(currentTime);

        FindObjectOfType<Inventory>().newOrder(orderType);
    }

    // Update is called once per frame
    void Update()
    {
        // Sprawdzamy, czy czas jest wi�kszy od 0
        if (currentTime > 0 && !stopTimer)
        {
            // Odliczamy czas co klatk�
            currentTime -= Time.deltaTime;

            // Upewnij si�, �e czas nie spadnie poni�ej zera
            currentTime = Mathf.Max(currentTime, 0);

            // Wy�wietlanie odliczaj�cego czasu w konsoli (opcjonalnie)
            //Debug.Log("Pozosta�y czas: " + currentTime);
            FindObjectOfType<OrderBar>().SetTime(currentTime);
        }
        else
        {
            //if (currentTime == 0)
            //{
            //    // game overer
            //}
            // Mo�na tu doda� akcj� po zako�czeniu odliczania
            Debug.Log("Odliczanie zako�czone!");
        }
    }

    public int getItemIndex(string name)
    {
        if (requiredItems.Contains(name))
        {
            return requiredItems.IndexOf(name);
        }
        else{
            return 0;
        }
    }

    // Funkcja ustawiaj�ca wymagane przedmioty na podstawie typu zam�wienia
    void SetOrderItems(int orderType)
    {
        blankItems.Clear();
        selectedItems.Clear();

        switch (orderType)
        {
            // klawiarura
            case 0:
                requiredItems = itemsForOrderType0;

                selectedItems.Add(przycisk);
                selectedItems.Add(przycisk);
                selectedItems.Add(screwdriver);

                blankItems.Add(przycisk);
                blankItems.Add(przycisk);
                blankItems.Add(screwdriver);
                Debug.Log("Zam�wienie typu 0. Wymagane przedmioty: " + string.Join(", ", requiredItems));
                break;
            // kabelki
            case 1:
                requiredItems = itemsForOrderType1;

                selectedItems.Add(kabel);
                selectedItems.Add(kabel);
                selectedItems.Add(lutownica);

                blankItems.Add(kabel);
                blankItems.Add(kabel);
                blankItems.Add(lutownica);

                Debug.Log("Zam�wienie typu 1. Wymagane przedmioty: " + string.Join(", ", requiredItems));
                break;
            case 2:
                requiredItems = itemsForOrderType2;

                selectedItems.Add(lutownica);
                selectedItems.Add(rezystor);
                selectedItems.Add(kabel);

                blankItems.Add(lutownica);
                blankItems.Add(rezystor);
                blankItems.Add(kabel);

                Debug.Log("Zam�wienie typu 2. Wymagane przedmioty: " + string.Join(", ", requiredItems));
                break;
            default:
                Debug.LogWarning("Nieznany typ zam�wienia!");
                break;
        }
    }

    // update time bar for order
    public void countDown()
    {
        orderBar.SetTime(currentTime);
    }

    public int getPoints()
    {
        int points = Mathf.RoundToInt((currentTime / countdownTime) * maxPoints);
        return points;
    }

    // Sprawdzenie, czy przedmiot jest wymagany w aktualnym zam�wieniu
    public bool IsItemRequired(string itemName)
    {
        return requiredItems.Contains(itemName);
    }
}