using UnityEngine;
using System.Collections;

public class DelayedSongPlayer : MonoBehaviour
{
    public float delayTime = 2f; // Set the desired delay time in seconds
    public AudioClip songClip; // Assign the audio clip you want to play

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayDelayedSong());
    }

    private IEnumerator PlayDelayedSong()
    {
        yield return new WaitForSeconds(delayTime);

        audioSource.clip = songClip;
        audioSource.Play();
    }
}
