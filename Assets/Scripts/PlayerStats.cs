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
        UIController.instance.UpdateHealthSlider(health, maxHealth);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool gameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameOver)
        {
            return;
        }
        Debug.Log("Player damaged");
        health--;
        UIController.instance.UpdateHealthSlider(health, maxHealth);  
        if (health <= 0)
        {
           Debug.Log("Game Over");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game Over");
        }
    }
}