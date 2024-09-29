using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public GameObject Options;
    public GameObject Tutorial;
    public GameObject AuthorsScreen;

    private void Start()
    {
        Options.SetActive(false);
        Tutorial.SetActive(false);  
        AuthorsScreen.SetActive(false);
    }

    public void play()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void options()
    {
        Options.SetActive(true);
    }

    public void tutorial()
    {
        Tutorial.SetActive(true);
    }

    public void authors()
    {
        AuthorsScreen.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void back()
    {
        Options.SetActive(false);
        Tutorial.SetActive(false);
        AuthorsScreen.SetActive(false);
    }

    public void AcctivateAuthorsScreen()
    {
        AuthorsScreen.SetActive(true);
    }
}
