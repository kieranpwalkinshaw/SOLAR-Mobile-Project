using Unity.VisualScripting;
using UnityEngine;

public class SOLARBullet : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0f, SOLARWeapons.Instance.speed * Time.deltaTime);
        if (transform.position.y > Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y)
        {
            Destroy(gameObject);
        }


    }
}
