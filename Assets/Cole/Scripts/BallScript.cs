using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private FixedJoint joint;
    private GameObject lastRope;

    // Start is called before the first frame update
    void Start()
    {
        // Get Character Joint component
        joint = GetComponent<FixedJoint>();

        // Find the pole
        int i = 0;
        while (true)
        {
            i++;
            GameObject rope = GameObject.Find("Rope " + i);
            if (rope == null)
            {
                break;
            }
            lastRope = rope;
        }

        // Attach ball to end of rope
        joint.transform.position = lastRope.transform.position + new Vector3(0, 0, 0);
        joint.connectedBody = lastRope.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
