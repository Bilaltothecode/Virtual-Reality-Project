using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    [SerializeField]
    Animator fadeAnimator;

    bool fell = false;

    void Update()
    {
        if (!fell && transform.position.y < 1.5f)
        {
            fell = true;
            StartCoroutine(SwitchScene());
        }
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(3);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("8");
    }
}
