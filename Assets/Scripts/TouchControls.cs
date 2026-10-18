using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class touchControls : MonoBehaviour
{
    private void Awake()
    {
        Instance = this;
    }
    //declare variables
    public bool isTap = false;
    private bool isDragging = false;
    private bool touchStarted = false;
    private float Xoffset;
    private float fixedY;
    //declare variables for the left and right boundaries of the screen
    private float maxLeft; 
    private float maxRight;

    private Vector2 touchStartPos;
    [SerializeField] private float tapThreshold = 0.1f; // Adjust this value to set the maximum distance for a tap

    private UnityEngine.Camera mainCamera;
    public static touchControls Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        maxLeft = mainCamera.ViewportToWorldPoint(new Vector2(0.12f, 0)).x; // Set the left boundary to 12f
        maxRight = mainCamera.ViewportToWorldPoint(new Vector2(0.88f, 0)).x; // Set the right boundary to 88f
    }//end of start



    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)// if there is at least one touch on the screen, set touch to the first touch in the array and set touchPosition to the world position of the touch
        {
            Touch touch = Input.GetTouch(0); // get the first touch in the array

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    touch.position.x,
                    touch.position.y,
                    -Camera.main.transform.position.z
                ) //get the world position of the touch by converting the screen position to the world position with the camera pos
            );

            if (touch.phase == TouchPhase.Began) // if the touch has just begun, check if there is a collider at the touch position and if it is the SOLAR 
            {
                isDragging = false; 
                touchStartPos = touchPosition;

                Collider2D collider = Physics2D.OverlapPoint(touchPosition); // check if there is a collider at the touch position

                if (collider != null && collider.gameObject == gameObject) // if there is a collider and it is the SOLAR, set dragging to true and calculate the offset
                {
                    isDragging = true;
                    Xoffset = touchPosition.x - transform.position.x; //find the offset between the touch position and the ship position
                    fixedY = transform.position.y; //keep the Y fixded so the ship doesn't move up and down
                }
                else // if there is no collider or it is not the ship
                {
                    isTap = true;

                }
            }


            if (isDragging &&
                (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)) // if dragging is true and the touch is moving or stationary, update the position of the SOLAR
            {

                float distanceMoved = Vector2.Distance(touchPosition, touchStartPos); //set distancemoved to the distance betweeen the start and current touch position
                if (distanceMoved > tapThreshold) //if the distance moved is more than the set threshold
                {
                    isTap = false; // If the distance moved exceeds the threshold, it's not a tap
                    isDragging = true; // it is now a drag input
                }
                if (isDragging)
                {
                    float newX = touchPosition.x - Xoffset; //set the ships new x pos to the touch position - the offset

                    transform.position = new Vector3(Mathf.Clamp(newX, maxLeft, maxRight), fixedY, transform.position.z); //set the ships position to the new x, the fixed y and the current z
                }

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) //if the touch has ended or been canceled, set dragging to false
                {
                    if (!isDragging)
                    {
                        isTap = true; // If the touch isnt a drag, it's a tap
                    }

                    touchStarted = false;
                    isDragging = false;
                }
            }
        }
    }//end of update

    //start of button functions
    public void Heal()
    {
        if (PlayerStats.instance.energy >= 3 && PlayerStats.instance.health < PlayerStats.instance.maxHealth) // if the energy meter is more than or = 3 and their health isnt full
        {
            AudioManager.instance.PlaySound(AudioManager.instance.button);
            PlayerStats.instance.health++;
            PlayerStats.instance.energy -= 3;
            UIController.instance.UpdateHealthSlider(PlayerStats.instance.health, PlayerStats.instance.maxHealth);
            UIController.instance.UpdateEnergySlider(PlayerStats.instance.energy, PlayerStats.instance.maxEnergy);
        }
    }
}