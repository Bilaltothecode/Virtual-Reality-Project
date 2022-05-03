using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDetector : MonoBehaviour
{
    enum Colour
    {
        Any,
        Tag
    }
    [HideInInspector]
    public int totalWeight;

    [SerializeField]
    Colour acceptedColours = Colour.Any;
    [SerializeField]
    AudioClip confirmSound;
    [SerializeField]
    AudioSource source;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag) || (acceptedColours == Colour.Any && (other.CompareTag("Any") || other.CompareTag("Red") || other.CompareTag("Green") || other.CompareTag("Blue"))))
        {
            totalWeight += (int)Mathf.Floor(other.GetComponent<Rigidbody>().mass);
            source.PlayOneShot(confirmSound);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag) || (acceptedColours == Colour.Any && (other.CompareTag("Any") || other.CompareTag("Red") || other.CompareTag("Green") || other.CompareTag("Blue"))))
            totalWeight -= (int)Mathf.Floor(other.GetComponent<Rigidbody>().mass);
    }
}
