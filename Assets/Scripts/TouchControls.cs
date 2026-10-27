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
    private float Xoffset;
    private float fixedY;
    private int dragFingerId = -1;
    //declare variables for the left and right bounds of the screen
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
        maxLeft = mainCamera.ViewportToWorldPoint(new Vector2(0.12f, 0)).x;
        maxRight = mainCamera.ViewportToWorldPoint(new Vector2(0.88f, 0)).x;
    }//end of start



    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    touch.position.x,
                    touch.position.y,
                    -Camera.main.transform.position.z
                )
            ); // convert the touch position from screen space to world space

            if (touch.phase == TouchPhase.Began) // if the touch has just begun, check if there is a collider at the touch position and if it is the SOLAR 
            {
                isDragging = false;
                touchStartPos = touchPosition;

                Collider2D collider = Physics2D.OverlapPoint(touchPosition);

                if (collider != null && collider.gameObject == gameObject) // if there is a collider and it is the SOLAR, set dragging to true and calculate the offset
                {
                    isDragging = true;
                    dragFingerId = touch.fingerId;
                    Xoffset = touchPosition.x - transform.position.x; // calculate the offset between the touch position and the SOLAR's position
                    fixedY = transform.position.y; // store the fixed y position of the SOLAR so it doesn't move vertically
                }
                else
                {
                    isTap = true;

                }
            }


            if (isDragging && touch.fingerId == dragFingerId &&
                (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)) // if dragging is true and the touch is moving or stationary, update the position of the SOLAR
            {

                float distanceMoved = Vector2.Distance(touchPosition, touchStartPos);
                if (distanceMoved > tapThreshold)
                {
                    isTap = false; // If the distance moved exceeds the threshold, it's not a tap
                    isDragging = true; // it is now a drag input

                }
                if (isDragging && touch.fingerId == dragFingerId) //if the player is dragging
                {
                    float newX = touchPosition.x - Xoffset; // calculate the new x position based on the touch position and the offset

                    transform.position = new Vector3(Mathf.Clamp(newX, maxLeft, maxRight), fixedY, transform.position.z); // clamp the new position to the left and right bounds
                }

                if (isDragging && touch.fingerId == dragFingerId && touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) //if the touch has ended or been canceled, set dragging to false
                {
                   

                    isDragging = false;
                }
            }
        }
    }//end of update

    //start of button functions
    public void Heal()
    {
        if (PlayerStats.instance.energy >= 3 && PlayerStats.instance.health < PlayerStats.instance.maxHealth) //if the player has enough energy and is not at max health
        {
            AudioManager.instance.PlaySound(AudioManager.instance.button); //play button sound
            PlayerStats.instance.health++; //increase health by 1
            PlayerStats.instance.energy -= 3; //deplete energy
            UIController.instance.UpdateHealthSlider(PlayerStats.instance.health, PlayerStats.instance.maxHealth); //update health slider
            UIController.instance.UpdateEnergySlider(PlayerStats.instance.energy, PlayerStats.instance.maxEnergy);//update energy slider
        }
    }
}