using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene5ButtonPress : MonoBehaviour
{
    [SerializeField]
    Animator buttonAnimator, hammerAnimator, fadeAnimator;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip buttonSound;

    bool isPressed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonAnimator.SetBool("Pressed", true);
            source.PlayOneShot(buttonSound);

            if (!isPressed)
            {
                isPressed = true;
                hammerAnimator.SetTrigger("Swing");
                StartCoroutine(SwitchScene());
            }
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

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(5);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("6");
    }
}
