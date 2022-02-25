using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private ConfigurableJoint joint;
    private GameObject lastRope;

    // Start is called before the first frame update
    void Start()
    {
        // Get Character Joint component
        joint = GetComponent<ConfigurableJoint>();

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
        joint.connectedBody = lastRope.GetComponent<Rigidbody>();
        joint.connectedAnchor = new Vector3(0, 1, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
