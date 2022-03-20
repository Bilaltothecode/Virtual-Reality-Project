using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscoPartyController : MonoBehaviour
{
    [SerializeField]
    GameObject discoParent;
    [SerializeField]
    Animator buttonAnimator, fadeAnimator;
    [SerializeField]
    AudioClip buttonSound;
    [SerializeField]
    AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (discoParent.activeSelf)
                StartCoroutine(SwitchScene());

            discoParent.SetActive(!discoParent.activeSelf);
            buttonAnimator.SetBool("Pressed", true);
            source.PlayOneShot(buttonSound);
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
        yield return new WaitForSeconds(1);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("10");
    }
}
