using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2WeightChecker : WeightChecker
{
    [SerializeField]
    GameObject plank;
    [SerializeField]
    Animator fadeAnimator;

    protected override void HitTarget()
    {
        StartCoroutine(SwitchScene());
    }

    IEnumerator SwitchScene()
    {
        GameObject o = Instantiate(plank);
        o.transform.SetPositionAndRotation(fadeAnimator.transform.parent.parent.position, fadeAnimator.transform.parent.parent.rotation);
        yield return new WaitForSeconds(2);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(Flags.GetNextScene);
    }
}
