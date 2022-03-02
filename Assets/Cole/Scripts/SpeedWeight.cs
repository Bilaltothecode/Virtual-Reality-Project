using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedWeight : MonoBehaviour
{
    private SimpleCapsuleWithStickMovement player;
    private OVRGrabbable smallDumbell;
    private OVRGrabbable largeDumbell;
    public float baseSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<SimpleCapsuleWithStickMovement>();
        smallDumbell = GameObject.Find("Small Dumbell").GetComponent<OVRGrabbable>();
        largeDumbell = GameObject.Find("Large Dumbell").GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        player.Speed = baseSpeed;
        if (largeDumbell.isGrabbed)
        {
            player.Speed = baseSpeed * 0.33f;
        }
        else if (smallDumbell.isGrabbed)
        {
            player.Speed = baseSpeed * 0.66f;
        }
    }
}
