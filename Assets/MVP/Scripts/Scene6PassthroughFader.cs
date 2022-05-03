using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene6PassthroughFader : MonoBehaviour
{
    [SerializeField]
    GameObject plank;
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
        else
            centerEye = fadeAnimator.transform.parent.parent.gameObject;
    }

    void Update()
    {
        TogglePassthrough();
    }

    public void TogglePassthrough()
    {
        if (!switched && Vector3.Distance(transform.position, centerEye.transform.position) < 0.15f)
        {
            StartCoroutine(WaitFade());
            switched = true;
        }
        else if (switched && Vector3.Distance(transform.position, centerEye.transform.position) > 0.15f)
            switched = false;
    }

    IEnumerator WaitFade()
    {
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1);
        if (ovrManager != null)
            ovrManager.isInsightPassthroughEnabled = !ovrManager.isInsightPassthroughEnabled;
        room.SetActive(!room.activeSelf);
        realityText.SetActive(!realityText.activeSelf);
        fadeAnimator.SetBool("Faded", false);
        yield return new WaitForSeconds(3);
        GameObject o = Instantiate(plank);
        o.transform.SetPositionAndRotation(fadeAnimator.transform.parent.parent.position, fadeAnimator.transform.parent.parent.rotation);
        yield return new WaitForSeconds(3);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(Flags.GetNextScene);
    }
}
