using Unity.VisualScripting;
using UnityEngine;

public class SOLARWeapons : MonoBehaviour
{
    public static SOLARWeapons Instance;

    [SerializeField] private GameObject prefab;
    //declare speed and damage variables
    public float speed;
    public int damage;
    public float shotCooldown;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        shotCooldown += Time.deltaTime;
        if (touchControls.Instance.isTap && shotCooldown >= 0.7f) // check if the player has tapped the screen
        {
            Shoot(); 
        }
    }
    

    public void Shoot()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.shot); // Play the shot sound effect
        Instantiate(prefab, transform.position, transform.rotation); // spawn a bullet at the position of the weapon
        touchControls.Instance.isTap = false; // reset the isTap variable to false after shooting
        shotCooldown = 0f; // start the shot cooldown
    }
}
