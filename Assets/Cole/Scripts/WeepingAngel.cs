using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingAngel : MonoBehaviour
{
    public OVRCameraRig cameraRig;
    public float speed = 0.5f;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use the dot product of the camera rig's forward vector and the object's relative position to determine if cameraRig can see object
        if (Vector3.Dot(cameraRig.centerEyeAnchor.forward, transform.position - cameraRig.centerEyeAnchor.position) < 0)
        {
            // Move object towards cameraRig at rate of speed, and set rotation to face cameraRig horizontally based on cameraRig's forward vector and relative position
            transform.position = Vector3.MoveTowards(transform.position, cameraRig.centerEyeAnchor.position, speed * Time.deltaTime);
            Vector3 lookPos = cameraRig.transform.position - transform.position;
            lookPos.y = 0;
            lookPos = -lookPos;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
    }
}
