using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3WeightChecker : WeightChecker
{
    [SerializeField]
    Animator fadeAnimator;

    protected override void HitTarget()
    {
        StartCoroutine(SwitchScene());
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(2);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("4");
    }
}
