using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject CameraRig;
    public GameObject PhotoCamera;
    public GameObject Eyecenter;
    bool switched = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        togglepassthrough();
    }
    public void togglepassthrough()
    {
        if (!switched && Vector3.Distance(PhotoCamera.transform.position, Eyecenter.transform.position) < 1f)
        {
            CameraRig.GetComponent<OVRManager>().isInsightPassthroughEnabled = !CameraRig.GetComponent<OVRManager>().isInsightPassthroughEnabled;
            StartCoroutine(WaitFade());     //for fading
            switched = true;
        }
        else if (switched && Vector3.Distance(PhotoCamera.transform.position, Eyecenter.transform.position) > 1f)
        {
            switched = false;
        }
    }
    IEnumerator WaitFade()      //fading
    {
        yield return new WaitForSeconds(3);
        // Do things after 3 seconds
        Debug.Log("HI");
    }
}

