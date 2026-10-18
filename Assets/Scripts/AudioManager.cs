using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;

    public AudioSource explosion;
    public AudioSource shot;
    public AudioSource button;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioSource sound)
    {
        sound.pitch = Random.Range(0.7f, 1.3f);
        sound.Stop();
        sound.Play();
    }
}
