using Unity.VisualScripting;
using UnityEngine;

public class SOLARBullet : MonoBehaviour
{
    private void Awake()
    {
        instance = this;
    }
    public static SOLARBullet instance;
    void Update()
    {
        transform.position += new Vector3(0f, SOLARWeapons.Instance.speed * Time.deltaTime);
        if (transform.position.y > Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y)
        {
            Destroy(gameObject);
        }
    }

        private void OnCollisionEnter2D(Collision2D collision) 
        { 
            if (collision.gameObject.CompareTag("Enemy"))
            {
            Debug.Log("Bullet hit enemy");
            Destroy(gameObject);
            UIController.instance.UpdateScoreText(score: PlayerStats.instance.Score += 50);
            UIController.instance.UpdateEnergySlider(PlayerStats.instance.energy += 1, PlayerStats.instance.maxEnergy);
        }
        }   
}
