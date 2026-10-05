using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class touchControls : MonoBehaviour
{
    private void Awake()
    {
        Instance = this;
    }

    public bool isTap = false;
    private bool isDragging = false;
    private bool touchStarted = false;
    private float Xoffset;
    private float fixedY;

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
        if (Input.touchCount > 0)// if there is at least one touch on the screen, set touch to the first touch in the array and set touchPosition to the world position of the touch
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    touch.position.x,
                    touch.position.y,
                    -Camera.main.transform.position.z
                )
            );

            if (touch.phase == TouchPhase.Began) // if the touch has just begun, check if there is a collider at the touch position and if it is the SOLAR 
            {
                isDragging = false;
                touchStartPos = touchPosition;

                Collider2D collider = Physics2D.OverlapPoint(touchPosition);

                if (collider != null && collider.gameObject == gameObject) // if there is a collider and it is the SOLAR, set dragging to true and calculate the offset
                {
                    isDragging = true;
                    Xoffset = touchPosition.x - transform.position.x;
                    fixedY = transform.position.y;
                }
                else
                {
                    isTap = true;

                }
            }


            if (isDragging &&
                (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)) // if dragging is true and the touch is moving or stationary, update the position of the SOLAR
            {

                float distanceMoved = Vector2.Distance(touchPosition, touchStartPos);
                if (distanceMoved > tapThreshold)
                {
                    isTap = false; // If the distance moved exceeds the threshold, it's not a tap
                    isDragging = true; // it is now a drag input
                }
                if (isDragging)
                {
                    float newX = touchPosition.x - Xoffset;

                    transform.position = new Vector3(Mathf.Clamp(newX, maxLeft, maxRight), fixedY, transform.position.z);
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
        if (PlayerStats.instance.energy >= 3 && PlayerStats.instance.health < PlayerStats.instance.maxHealth)
        {
            PlayerStats.instance.health++;
            PlayerStats.instance.energy -= 3;
            UIController.instance.UpdateHealthSlider(PlayerStats.instance.health, PlayerStats.instance.maxHealth);
            UIController.instance.UpdateEnergySlider(PlayerStats.instance.energy, PlayerStats.instance.maxEnergy);
        }
    }
}