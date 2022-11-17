using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;
    public static AudioHandler Instance = null;
	
    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //     }
    //     else if (Instance != this)
    //     {
    //         Destroy(gameObject);
    //     }
    //     DontDestroyOnLoad (gameObject);
    // }
    //
    // public void Play(AudioClip clip)
    // {
    //     EffectsSource.clip = clip;
    //     EffectsSource.Play();
    // }
    //
    // public void PlayMusic(AudioClip clip)
    // {
    //     MusicSource.clip = clip;
    //     MusicSource.Play();
    // }

    
}
