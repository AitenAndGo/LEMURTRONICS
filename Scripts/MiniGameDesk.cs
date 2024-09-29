using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameDesk : MonoBehaviour
{
    int miniGameIndex;
    private bool playerInRange = false; // Czy gracz jest w zasi�gu interakcji

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

    // Update jest wywo�ywane raz na klatk�
    void Update()
    {
        // Sprawdza, czy gracz jest w zasi�gu i czy naci�ni�to klawisz "E"
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ActivateMiniGame(); // Wywo�anie funkcji aktywuj�cej minigr� lub inn� akcj�
        }
    }

    // Funkcja aktywuj�ca minigr� (lub inn� akcj�)
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
        // Dezaktywacja innych obiekt�w w razie potrzeby...
        // �aduje minigr� w trybie additive (g��wna scena pozostaje aktywna)
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
}

