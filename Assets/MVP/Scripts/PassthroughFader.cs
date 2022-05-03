using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassthroughFader : MonoBehaviour
{
    [SerializeField]
    Animator fadeAnimator;
    [SerializeField]
    GameObject room;

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
        room.SetActive(!ovrManager.isInsightPassthroughEnabled);
        fadeAnimator.SetBool("Faded", false);
    }
}
