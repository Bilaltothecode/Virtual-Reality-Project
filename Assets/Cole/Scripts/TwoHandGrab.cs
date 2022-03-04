using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandGrab : MonoBehaviour
{
    private Rigidbody rb;
    private OVRGrabbable grab;
    public OVRGrabber left;
    public OVRGrabber right;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        // If object is being held by both hands, OR neither hand
        if ((left.grabbedObject == grab) == (right.grabbedObject == grab))
        {
            // Normal physics
            rb.isKinematic = false;
        }
        // If object is being held by one hand
        else if (left.grabbedObject == grab ^ right.grabbedObject == grab)
        {
            // Unmovable
            rb.isKinematic = true;
        }
        // If object is stationary ie. on ground
        else if (rb.velocity == new Vector3(0, 0, 0) && rb.angularVelocity == new Vector3(0, 0, 0))
        {
            // Drop it
            grab.grabbedBy.ForceRelease(grab);
        }
    }
}

