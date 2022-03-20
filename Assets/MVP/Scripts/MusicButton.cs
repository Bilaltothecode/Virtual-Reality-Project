using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    [SerializeField]
    Animator buttonAnimator;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip buttonSound, musicTone;
    [SerializeField]
    MusicController musicController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonAnimator.SetBool("Pressed", true);
            source.PlayOneShot(buttonSound);
            source.PlayOneShot(musicTone);
            musicController.DidTone(musicTone);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonAnimator.SetBool("Pressed", false);
            source.PlayOneShot(buttonSound);
        }
    }
}
