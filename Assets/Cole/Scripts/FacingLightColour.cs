using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingLightColour : MonoBehaviour
{
    public OVRCameraRig cameraRig;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Use dot product to determine if cameraRig is facing the light
        if (Vector3.Dot(cameraRig.centerEyeAnchor.forward, transform.forward) > 0)
        {
            GetComponent<Light>().color = Color.green;
        }
        else
        {
            GetComponent<Light>().color = Color.red;
        }
    }
}
