using NUnit.Framework.Constraints;
using System.Xml;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public static Dart instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private int health;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,-speed * Time.deltaTime, 0);
        if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, -0)).y)
        {
            Destroy(gameObject);
        }
    }
}
