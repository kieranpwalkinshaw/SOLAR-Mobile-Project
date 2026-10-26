using Unity.VisualScripting;
using UnityEngine;

public class SOLARBullet : MonoBehaviour
{
    private void Awake()
    {
        instance = this;
    }
    public static SOLARBullet instance;
    void Update()
    {
        transform.position += new Vector3(0f, SOLARWeapons.Instance.speed * Time.deltaTime); // move the bullet upwards based on the speed of the weapon
        if (transform.position.y > Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y) // if the bullet has moved off the top of the screen, destroy it
        {
            Destroy(gameObject);
        }
    }

        private void OnCollisionEnter2D(Collision2D collision) 
        { 
            if (collision.gameObject.CompareTag("Enemy")) // if the bullet collides with an enemy
        {
            Debug.Log("Bullet hit enemy"); // log a message to the console for dev confrimation
            Destroy(gameObject); // destroy the bullet
            AudioManager.instance.PlaySound(AudioManager.instance.explosion); // play the explosion sound effect
            UIController.instance.UpdateScoreText(score: PlayerStats.instance.Score += 100); // update the score text in the UI by adding 100 to the player's score
            UIController.instance.UpdateEnergySlider(PlayerStats.instance.energy += 1, PlayerStats.instance.maxEnergy); // update the energy slider in the UI by adding 1 to the player's energy
            SOLARWeapons.Instance.shotCooldown = 0.7f;
        }
        }   
}
