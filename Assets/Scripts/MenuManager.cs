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
        Application.Quit(); // exit the program
    }

    public void PlayGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play Screen"); // change scene to Play Screen
    }

    public void HelpScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Help Screen"); //change scene to Help Screen
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");//change scene to Main Menu
    }
}
