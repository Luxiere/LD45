using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandomizer : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;

    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            Randomize();
        }
    }

    private void Randomize()
    {
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }
}
