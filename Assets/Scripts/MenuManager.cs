using UnityEngine;

public class MenuManager : MonoBehaviour
{
   

    public static MenuManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void PlayGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play Screen");
    }

    public void HelpScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Help Screen");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
