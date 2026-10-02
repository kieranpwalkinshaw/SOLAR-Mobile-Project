using Unity.VisualScripting;
using UnityEngine;

public class SOLARWeapons : MonoBehaviour
{
    public static SOLARWeapons Instance;

    [SerializeField] private GameObject prefab;

    public float speed;
    public int damage;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (touchControls.Instance.isTap)
        {
            Shoot();
        }
    }
    

    public void Shoot()
    {
        Instantiate(prefab, transform.position, transform.rotation);
        touchControls.Instance.isTap = false;
    }
}
