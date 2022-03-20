using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSpawnerButton : MonoBehaviour
{
    enum Colour
    {
        White,
        Red,
        Green,
        Blue
    }

    [SerializeField]
    Colour colour;
    [SerializeField]
    WeightSpawner weightSpawner;
    [SerializeField]
    Animator buttonAnimator;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip buttonSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonAnimator.SetBool("Pressed", true);
            source.PlayOneShot(buttonSound);

            string toSpawn;
            switch (colour)
            {
                case Colour.Red:
                    toSpawn = "red";
                    break;
                case Colour.Green:
                    toSpawn = "green";
                    break;
                case Colour.Blue:
                    toSpawn = "blue";
                    break;
                default:
                    toSpawn = "white";
                    break;
            }
            weightSpawner.SpawnWeight(toSpawn);
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
