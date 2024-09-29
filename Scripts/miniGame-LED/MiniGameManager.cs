using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject WinScreen;

    private string ActiveSceneName;

    public void Start()
    {
        gameOverScreen.SetActive(false);
        WinScreen.SetActive(false);
    }
    public void RestertMiniGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void BackToMainGame()
    {
        // Unloaduje minigrê po zakoñczeniu
        SceneManager.UnloadSceneAsync(ActiveSceneName);
    }

    public void GameOverScreen(string name)
    {
        gameOverScreen.SetActive(true);
        Invoke("RestertMiniGame", 3f);
    }

    public void winScreen(string name)
    {
        WinScreen.SetActive(true);
        ActiveSceneName = name;
        Invoke("BackToMainGame", 2f);
    }
}
