using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    [SerializeField]
    int startScene = 1;
    [SerializeField]
    bool reverseOrder = false;
    [SerializeField]
    Animator buttonAnimator, fadeAnimator;
    [SerializeField]
    AudioClip buttonSound;
    [SerializeField]
    AudioSource source;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonAnimator.SetBool("Pressed", true);
            source.PlayOneShot(buttonSound);

            if (!Flags.orderSet)
            {
                Flags.SetStartScene(startScene);
                Flags.reverseSceneOrder = reverseOrder;
                Flags.orderSet = true;
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
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(startScene.ToString());
    }
}
