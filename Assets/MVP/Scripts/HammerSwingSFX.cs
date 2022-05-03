using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSwingSFX : MonoBehaviour
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip swing, impactHeavy, impactLight;

    public void Swing()
    {
        source.PlayOneShot(swing);
    }

    public void Heavy()
    {
        source.PlayOneShot(impactHeavy);
    }

    public void Light()
    {
        source.PlayOneShot(impactLight);
    }

    public void Lighter()
    {
        source.PlayOneShot(impactLight, 0.5f);
    }
}
