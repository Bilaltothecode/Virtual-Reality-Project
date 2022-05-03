using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene6PassthroughFader : MonoBehaviour
{
    [SerializeField]
    Animator fadeAnimator;
    [SerializeField]
    GameObject realityText, room;

    GameObject centerEye;
    OVRManager ovrManager;
    bool switched = false;

    void Start()
    {
        centerEye = GameObject.Find("CenterEyeAnchor");
        if (centerEye != null)
            ovrManager = centerEye.GetComponentInParent<OVRManager>();
    }

    void Update()
    {
        if (centerEye != null)
            TogglePassthrough();
    }

    public void TogglePassthrough()
    {
        if (!switched && Vector3.Distance(transform.position, centerEye.transform.position) < 0.1f)
        {
            StartCoroutine(WaitFade());
            switched = true;
        }
        else if (switched && Vector3.Distance(transform.position, centerEye.transform.position) > 0.1f)
            switched = false;
    }

    IEnumerator WaitFade()
    {
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1);
        ovrManager.isInsightPassthroughEnabled = !ovrManager.isInsightPassthroughEnabled;
        realityText.SetActive(true);
        room.SetActive(false);
        fadeAnimator.SetBool("Faded", false);
        yield return new WaitForSeconds(6);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("7");
    }
}
