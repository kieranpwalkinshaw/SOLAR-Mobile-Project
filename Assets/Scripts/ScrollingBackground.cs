using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = scrollSpeed * Time.deltaTime;
        transform.position += new Vector3(0, moveY, 0); // move the background downwards based on the scroll speed (moveY)
        if (transform.position.y <= -10f) // if the background has scrolled down past the camera view, reset its position to the top of the screen
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
