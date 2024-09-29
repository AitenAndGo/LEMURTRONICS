using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameDesk : MonoBehaviour
{
    int miniGameIndex;
    private bool playerInRange = false; // Czy gracz jest w zasiêgu interakcji

    // Funkcja uruchamiana, gdy gracz wchodzi w obszar kolidera (trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player")) // Sprawdza, czy to gracz
        {
            playerInRange = true;
        }
    }

    // Funkcja uruchamiana, gdy gracz wychodzi z obszaru kolidera (trigger)
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player")) // Sprawdza, czy to gracz
        {
            playerInRange = false;
        }
    }

    // Update jest wywo³ywane raz na klatkê
    void Update()
    {
        // Sprawdza, czy gracz jest w zasiêgu i czy naciœniêto klawisz "E"
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ActivateMiniGame(); // Wywo³anie funkcji aktywuj¹cej minigrê lub inn¹ akcjê
        }
    }

    // Funkcja aktywuj¹ca minigrê (lub inn¹ akcjê)
    void ActivateMiniGame()
    {
        miniGameIndex = FindObjectOfType<Order>().orderType;
        switch (miniGameIndex)
        {
            case 0:
                LoadMiniGame("MINIGAME-LEDY");
                break;
        }
    }

    public void LoadMiniGame(string name)
    {
        // Dezaktywacja innych obiektów w razie potrzeby...
        // £aduje minigrê w trybie additive (g³ówna scena pozostaje aktywna)
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
}

