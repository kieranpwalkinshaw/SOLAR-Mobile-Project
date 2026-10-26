using Unity.VisualScripting;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    //declare a private variable for the scroll speed
    [SerializeField] private float scrollSpeed;
    public float worldSpeed;
    public static ScrollingBackground instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        scrollSpeed -= Time.deltaTime / 8;
        if (scrollSpeed < -8) { 
        scrollSpeed = -8;
        }
        worldSpeed -= Time.deltaTime / 8;
        if (worldSpeed < -12) { 
        worldSpeed = -12;
        }
        float moveY = scrollSpeed * Time.deltaTime; //set moveY to the scroll speed * deltatime
        transform.position += new Vector3(0, moveY, 0); // move the background downwards based on the scroll speed (moveY)
        if (transform.position.y <= -10f) // if the background has scrolled down past the camera view, reset its position to the top of the screen
        {
            transform.position = new Vector3(0, 0, 0); // reset the background position to the center of the screen
        }
    }
}
