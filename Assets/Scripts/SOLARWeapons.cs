using Unity.VisualScripting;
using UnityEngine;

public class SOLARWeapons : MonoBehaviour
{
    public static SOLARWeapons Instance;

    [SerializeField] private GameObject prefab; // the bullet prefab to be instantiated
    //declare variables for speed and damage of the bullet
    public float speed;
    public int damage;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (touchControls.Instance.isTap) //if the player taps the screen
        {
            Shoot(); //call the shoot function
        }
    }
    

    public void Shoot()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.shot);
        Instantiate(prefab, transform.position, transform.rotation);
        touchControls.Instance.isTap = false;
    }
}
