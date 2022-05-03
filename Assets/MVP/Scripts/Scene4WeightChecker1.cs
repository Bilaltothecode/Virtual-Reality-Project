using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene4WeightChecker1 : WeightChecker
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
        while (!Scene4WeightChecker2.weightGood)
            yield return null;

        GameObject o = Instantiate(plank);
        o.transform.SetPositionAndRotation(fadeAnimator.transform.parent.parent.position, fadeAnimator.transform.parent.parent.rotation);
        yield return new WaitForSeconds(2);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(Flags.GetNextScene);
    }
}
