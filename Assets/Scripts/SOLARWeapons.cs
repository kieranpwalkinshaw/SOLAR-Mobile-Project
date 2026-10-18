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
        Instantiate(prefab, transform.position, transform.rotation); //spawn the bullet at the position of the player
        touchControls.Instance.isTap = false; //reset the istap so the player can shoot again
    }
}
