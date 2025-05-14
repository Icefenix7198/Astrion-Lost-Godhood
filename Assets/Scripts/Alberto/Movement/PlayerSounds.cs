using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    AudioSource playerAudioSource;
    public AudioClip[] footSteps;

    // Start is called before the first frame update
    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    public void PlayFootStepSound()
    {
        int number = Random.Range(0, footSteps.Length - 1);

        playerAudioSource.PlayOneShot(footSteps[number]);
    }
}
