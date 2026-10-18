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
        AudioManager.instance.PlaySound(AudioManager.instance.button);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play Screen");
    }

    public void HelpScreen()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.button);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Help Screen");
    }

    public void MainMenu()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.button);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
