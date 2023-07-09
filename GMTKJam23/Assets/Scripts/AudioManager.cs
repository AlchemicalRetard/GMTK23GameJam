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

    private AudioSource audioSourceEffects;
    private AudioSource audioSourceMusic;
    private AudioSource audioSourceRageMode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSourceEffects = gameObject.AddComponent<AudioSource>();
            audioSourceMusic = gameObject.AddComponent<AudioSource>();
            audioSourceRageMode = gameObject.AddComponent<AudioSource>();

            audioSourceMusic.loop = true;
            audioSourceMusic.clip = gameMusic;
            audioSourceMusic.Play();
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(PlayRandomNoise());
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
