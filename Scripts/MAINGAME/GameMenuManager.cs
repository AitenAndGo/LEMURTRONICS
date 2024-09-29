using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject GameMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameMenu.SetActive(false);
    }

    private bool isMenuActive = false;  // Flaga do �ledzenia stanu menu
    void Update()
    {
        // Sprawd�, czy wci�ni�to klawisz Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Prze��cz stan menu (w��cz/wy��cz)
            isMenuActive = !isMenuActive;

            // W��cz lub wy��cz obiekt menu w zale�no�ci od stanu
            GameMenu.SetActive(isMenuActive);

            if (isMenuActive)
            {
                Debug.Log("timeScale:0");
                Time.timeScale = 0.0f;
            }
            else
            {
                isMenuActive = false;
                Time.timeScale = 1.0f;
            }
        }
    }

    public void back()
    {
        isMenuActive=false;
        GameMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        GameMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
