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
    //declare health and speed
    [SerializeField] private int health;
    //[SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,DartObjectSpawning.instance.speed * Time.deltaTime, 0); //move the dart down and multiply the speed by deltatime
        if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, -0)).y) //if the dart is off screen
        {
            Destroy(gameObject); //destroy the dart
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //on collision
    {
        health--; //-1 health
        PlayerStats.instance.Score -= 50;
        if (health <= 0) //if health is 0 or less
        {
            Destroy(gameObject); //destroy dart
        }
    }
}
