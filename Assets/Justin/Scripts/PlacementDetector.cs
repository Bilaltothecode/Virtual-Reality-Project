using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementDetector : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            source.PlayOneShot(source.clip);
        }
    }
}
