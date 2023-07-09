using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Player")]
    public AudioClip featherShootSound;
    public AudioClip eggShootSound;
    public AudioClip eggExplosionSound;
    public AudioClip deathMusic;

    [Header("Enemies")]
    public AudioClip[] noiseLibrary;
    public AudioClip enemyDeathSound;

    [Header("Background")]
    public AudioClip gameMusic;
    public AudioClip rageModeLayer;

    [Header("Menu")]
    public AudioClip menuMusic;  // Menu music AudioClip

    private AudioSource audioSourceEffects;
    private AudioSource audioSourceMusic;
    private AudioSource audioSourceMenu; // Menu music AudioSource
    private AudioSource audioSourceRageMode;
    private float timer = 1f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSourceEffects = gameObject.AddComponent<AudioSource>();
            audioSourceMusic = gameObject.AddComponent<AudioSource>();
            audioSourceMenu = gameObject.AddComponent<AudioSource>(); // Initialize menu AudioSource
            audioSourceRageMode = gameObject.AddComponent<AudioSource>();

            audioSourceMusic.loop = true;
            audioSourceMusic.clip = gameMusic;
            audioSourceMusic.Play(); // Starts playing the game music right away

            audioSourceMenu.loop = true; // Set menu music to loop
            audioSourceMenu.clip = menuMusic; // Assign menu music clip
            audioSourceMenu.Play(); // Starts playing the menu music right away
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(PlayRandomNoise());
    }

    void Update()
    {
        timer -= Time.deltaTime; // reduce timer by the elapsed time since last frame

        if (timer <= 0)
        {
            ReduceGameMusicVolume();
            timer = 1f; // reset timer
        }
    }


    public void ReduceGameMusicVolume()
    {
        audioSourceMusic.volume *= 0.7f; // reduce volume by 30%
    }
    public void SetMainMusicVolume(float volume)
    {
        audioSourceMusic.volume = Mathf.Clamp01(volume);
    }

    public void SetMenuMusicVolume(float volume)
    {
        audioSourceMenu.volume = Mathf.Clamp01(volume);
    }
    public void PlayFeatherShootSound()
    {
        audioSourceEffects.PlayOneShot(featherShootSound);
    }

    public void PlayEggShootSound()
    {
        audioSourceEffects.PlayOneShot(eggShootSound);
    }

    public void PlayEggExplosionSound()
    {
        audioSourceEffects.PlayOneShot(eggExplosionSound);
    }

    public void PlayDeathMusic()
    {
        audioSourceMusic.clip = deathMusic;
        audioSourceMusic.Play();
    }

    public void PlayEnemyDeathSound()
    {
        audioSourceEffects.PlayOneShot(enemyDeathSound);
    }

    public void ActivateRageMode()
    {
        audioSourceRageMode.loop = true;
        audioSourceRageMode.clip = rageModeLayer;
        audioSourceRageMode.Play();
    }

    public void DeactivateRageMode()
    {
        audioSourceRageMode.Stop();
    }

    public void StartMenuMusic()
    {
        audioSourceMenu.Play();
    }

    public void StopMenuMusic()
    {
        audioSourceMenu.Stop();
    }

    private IEnumerator PlayRandomNoise()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10)); // Random time between 5 and 10 seconds
            AudioClip randomNoise = noiseLibrary[Random.Range(0, noiseLibrary.Length)];
            audioSourceEffects.PlayOneShot(randomNoise);
        }
    }
}
