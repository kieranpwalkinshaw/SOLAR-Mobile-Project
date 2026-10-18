using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
    //set up the audio sources
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
        DontDestroyOnLoad(gameObject); //ensure the AudioManager gameobject isnt destroyed when changing scenes
    }

    public void PlaySound(AudioSource sound) //play provided sound
    {
        sound.pitch = Random.Range(0.7f, 1.3f); //randomise the pitch between the two given float variables
        sound.Stop(); //stop the sound effect if already playing
        sound.Play(); //play the sound effect
    }
}
