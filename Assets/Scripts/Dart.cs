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
    //declare private variables for health and speed
    [SerializeField] private int health;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,-speed * Time.deltaTime, 0); // move the dart downwards based on speed and deltaTime
        if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, -0)).y) // if the dart goes off screen
        {
            Destroy(gameObject); // destroy the dart
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)// if the dart collides with something
    {
        health--; // decrease health by 1
        if (health <= 0) // if no health remains
        {
            Destroy(gameObject); // destroy the dart
        }
    }
}
