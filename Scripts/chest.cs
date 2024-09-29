//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Chest : MonoBehaviour
//{
//    // Przedmiot w skrzynce
//    public string itemName;
//    private bool isPlayerNearby = false; // Czy gracz jest w pobli�u skrzynki?

//    // Odniesienie do ekwipunku gracza
//    public Inventory playerInventory;

//    // Update is called once per frame
//    void Update()
//    {
//        // Sprawdzamy, czy gracz jest w pobli�u i nacisn�� przycisk "E"
//        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
//        {
//            OpenChest();
//        }
//    }

//    // Funkcja otwierania skrzynki
//    void OpenChest()
//    {
//        Debug.Log("Otwierasz skrzynk�. Otrzyma�e� przedmiot: " + itemName);

//        // Dodaj przedmiot do ekwipunku
//        if (playerInventory != null)
//        {
//            playerInventory.AddItem(itemName);
//        }
//        else
//        {
//            Debug.LogWarning("Brak przypisanego ekwipunku.");
//        }

//        // Po otwarciu skrzynki mo�esz zniszczy� obiekt lub oznaczy� go jako pusty
//        Destroy(gameObject); // Opcjonalnie: Zniszcz skrzynk� po jej otwarciu
//    }

//    // Wykrywanie, czy gracz wszed� w obszar skrzynki
//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("Gracz w pobli�u skrzynki.");
//            isPlayerNearby = true;
//        }
//    }

//    // Wykrywanie, czy gracz opu�ci� obszar skrzynki
//    void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("Gracz opu�ci� obszar skrzynki.");
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
    private bool isPlayerNearby = false; // Czy gracz jest w pobli�u skrzynki?

    // Odniesienie do ekwipunku gracza
    public Inventory playerInventory;

    // Odniesienie do aktualnego zam�wienia
    public Order currentOrder;

    // Update is called once per frame
    void Update()
    {
        // Sprawdzamy, czy gracz jest w pobli�u i nacisn�� przycisk "E"
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("dodanoNowyItem");
            OpenChest();
        }
    }

    // Funkcja otwierania skrzynki
    void OpenChest()
    {
        //Debug.Log("Otwierasz skrzynk�. Znajdujesz przedmiot: " + itemName);

        // Sprawdzamy, czy przedmiot z tej skrzynki jest wymagany w zam�wieniu
        if (currentOrder != null && currentOrder.IsItemRequired(item.name))
        {
            // Dodaj przedmiot do ekwipunku, je�li jest potrzebny
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
            //Debug.Log("Przedmiot " + itemName + " nie jest potrzebny w obecnym zam�wieniu.");
        }
    }

    // Wykrywanie, czy gracz wszed� w obszar skrzynki
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("Gracz w pobli�u skrzynki.");
            isPlayerNearby = true;
        }
    }

    // Wykrywanie, czy gracz opu�ci� obszar skrzynki
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("Gracz opu�ci� obszar skrzynki.");
            isPlayerNearby = false;
        }
    }
}
