using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneProgresser : MonoBehaviour
{
    [SerializeField]
    GameObject plank;
    [SerializeField]
    Animator fadeAnimator;

    void Start()
    {
        StartCoroutine(SwitchScene());
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(Random.Range(15, 30));
        GameObject o = Instantiate(plank);
        o.transform.SetPositionAndRotation(fadeAnimator.transform.parent.parent.position, fadeAnimator.transform.parent.parent.rotation);
        yield return new WaitForSeconds(2);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(Flags.GetNextScene);
    }
}
