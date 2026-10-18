using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    [SerializeField] public int health = 3;
    [SerializeField] public int maxHealth = 3;
    [SerializeField] public int energy = 0;
    [SerializeField] public int maxEnergy = 3;
    public int Score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    void Start()
    {
        instance = this;
        health = maxHealth;
        UIController.instance.UpdateHealthSlider(health, maxHealth); //set the health slider to the max health at the start of the game

    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool gameOver = false;

    private void OnCollisionEnter2D(Collision2D collision) //on collision
    {
        if (gameOver)
        {
            return;
        }
        Debug.Log("Player damaged"); //log the damage for dev confirm
        health--; //-1 health
        UIController.instance.UpdateHealthSlider(health, maxHealth); //update the health display  
        if (health <= 0) //if player health is at 0 or lower
        {
            AudioManager.instance.PlaySound(AudioManager.instance.explosion); //play explosion sound
            Debug.Log("Game Over"); //log death for dev confirm
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game Over"); //load game over screen
        }
    }
}