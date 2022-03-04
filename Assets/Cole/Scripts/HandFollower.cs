using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollower : MonoBehaviour
{
    public OVRInput.Controller target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = OVRInput.GetLocalControllerPosition(target);
        transform.rotation = OVRInput.GetLocalControllerRotation(target);
    }
}
