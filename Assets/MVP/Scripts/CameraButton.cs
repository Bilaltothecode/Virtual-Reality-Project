using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButton : MonoBehaviour
{
    [SerializeField]
    VirtualCameraController virtualCameraController;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip buttonSound, shutterSound;
    [SerializeField]
    Animator buttonAnimator;

    bool isPressed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isPressed)
            {
                isPressed = true;
                buttonAnimator.SetBool("Pressed", true);
                source.PlayOneShot(buttonSound);
                source.PlayOneShot(shutterSound);
                virtualCameraController.TakePicture();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPressed = false;
            buttonAnimator.SetBool("Pressed", false);
            source.PlayOneShot(buttonSound);
        }
    }

}
