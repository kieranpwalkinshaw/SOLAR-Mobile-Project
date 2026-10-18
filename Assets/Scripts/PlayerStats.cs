using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    //declare private variables for health / energy values and score
    [SerializeField] public int health = 3;
    [SerializeField] public int maxHealth = 3;
    [SerializeField] public int energy = 0;
    [SerializeField] public int maxEnergy = 3;
    public int Score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    void Start()
    {
        instance = this;
        health = maxHealth; // set health initially to max
        UIController.instance.UpdateHealthSlider(health, maxHealth); //update the health slider

    }

    // Update is called once per frame
    void Update()
    {
        if (energy > maxEnergy) // if energy is > than max energy, set energy to max energy
        {
            energy = maxEnergy;
        }
    }

    private bool gameOver = false;

    private void OnCollisionEnter2D(Collision2D collision) // on a collision
    {
        if (gameOver)
        {
            return;
        }
        Debug.Log("Player damaged"); // confirm there was a collision (dev confirmation for testing)
        health--; // take away 1 health
        UIController.instance.UpdateHealthSlider(health, maxHealth);  // update the health slider
        if (health <= 0)
        {
           Debug.Log("Game Over"); //confirm game over (dev confirmation for testing)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game Over"); // change scene to Game Over
        }
    }
}