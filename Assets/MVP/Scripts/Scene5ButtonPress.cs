using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene5ButtonPress : MonoBehaviour
{
    [SerializeField]
    Animator buttonAnimator, fadeAnimator;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip buttonSound;
    [SerializeField]
    GameObject fadeCanvas, plank;

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
                GameObject o = Instantiate(plank);
                o.transform.SetPositionAndRotation(fadeCanvas.transform.parent.position, fadeCanvas.transform.parent.rotation);
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
