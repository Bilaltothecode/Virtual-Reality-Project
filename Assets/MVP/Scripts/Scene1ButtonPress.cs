using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1ButtonPress : MonoBehaviour
{
    [SerializeField]
    Animator buttonAnimator, lightsAnimator, fadeAnimator;
    [SerializeField]
    AudioClip switchSound, buttonSound;
    [SerializeField]
    AudioSource source;

    bool lightsOn = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonAnimator.SetBool("Pressed", true);
            source.PlayOneShot(buttonSound);

            if (!lightsOn)
            {
                lightsOn = true;
                lightsAnimator.SetTrigger("On");
                AudioSource.PlayClipAtPoint(switchSound, lightsAnimator.transform.Find("Pillar Light").transform.position);
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
        yield return new WaitForSeconds(8);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("2");
    }
}
