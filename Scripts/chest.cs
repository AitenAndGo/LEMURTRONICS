//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Chest : MonoBehaviour
//{
//    // Przedmiot w skrzynce
//    public string itemName;
//    private bool isPlayerNearby = false; // Czy gracz jest w pobli¿u skrzynki?

//    // Odniesienie do ekwipunku gracza
//    public Inventory playerInventory;

//    // Update is called once per frame
//    void Update()
//    {
//        // Sprawdzamy, czy gracz jest w pobli¿u i nacisn¹³ przycisk "E"
//        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
//        {
//            OpenChest();
//        }
//    }

//    // Funkcja otwierania skrzynki
//    void OpenChest()
//    {
//        Debug.Log("Otwierasz skrzynkê. Otrzyma³eœ przedmiot: " + itemName);

//        // Dodaj przedmiot do ekwipunku
//        if (playerInventory != null)
//        {
//            playerInventory.AddItem(itemName);
//        }
//        else
//        {
//            Debug.LogWarning("Brak przypisanego ekwipunku.");
//        }

//        // Po otwarciu skrzynki mo¿esz zniszczyæ obiekt lub oznaczyæ go jako pusty
//        Destroy(gameObject); // Opcjonalnie: Zniszcz skrzynkê po jej otwarciu
//    }

//    // Wykrywanie, czy gracz wszed³ w obszar skrzynki
//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("Gracz w pobli¿u skrzynki.");
//            isPlayerNearby = true;
//        }
//    }

//    // Wykrywanie, czy gracz opuœci³ obszar skrzynki
//    void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("Gracz opuœci³ obszar skrzynki.");
//            isPlayerNearby = false;
//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Przedmiot w skrzynce
    public GameObject item;
    private bool isPlayerNearby = false; // Czy gracz jest w pobli¿u skrzynki?

    // Odniesienie do ekwipunku gracza
    public Inventory playerInventory;

    // Odniesienie do aktualnego zamówienia
    public Order currentOrder;

    // Update is called once per frame
    void Update()
    {
        // Sprawdzamy, czy gracz jest w pobli¿u i nacisn¹³ przycisk "E"
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("dodanoNowyItem");
            OpenChest();
        }
    }

    // Funkcja otwierania skrzynki
    void OpenChest()
    {
        //Debug.Log("Otwierasz skrzynkê. Znajdujesz przedmiot: " + itemName);

        // Sprawdzamy, czy przedmiot z tej skrzynki jest wymagany w zamówieniu
        if (currentOrder != null && currentOrder.IsItemRequired(item.name))
        {
            // Dodaj przedmiot do ekwipunku, jeœli jest potrzebny
            if (playerInventory != null)
            {
                int index = currentOrder.getItemIndex(item.name);
                playerInventory.AddItem(index);
                //Debug.Log("Dodano " + itemName + " do ekwipunku.");
            }
            else
            {
                Debug.LogWarning("Brak przypisanego ekwipunku.");
            }
        }
        else
        {
            //Debug.Log("Przedmiot " + itemName + " nie jest potrzebny w obecnym zamówieniu.");
        }
    }

    // Wykrywanie, czy gracz wszed³ w obszar skrzynki
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("Gracz w pobli¿u skrzynki.");
            isPlayerNearby = true;
        }
    }

    // Wykrywanie, czy gracz opuœci³ obszar skrzynki
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("Gracz opuœci³ obszar skrzynki.");
            isPlayerNearby = false;
        }
    }
}
