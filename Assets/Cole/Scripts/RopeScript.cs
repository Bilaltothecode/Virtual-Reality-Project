using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    private ConfigurableJoint joint;
    private GameObject pole;

    // Start is called before the first frame update
    void Start()
    {
        // Get Character Joint component
        joint = GetComponent<ConfigurableJoint>();

        // Find the pole
        pole = GameObject.Find("Pole");

        // Get the current rope number based off of name "Rope X";
        int currentRope = int.Parse(gameObject.name.Split(' ')[1]);

        // Find the next and previous rope game objects
        GameObject nextRope = GameObject.Find("Rope " + (currentRope + 1));
        GameObject prevRope = GameObject.Find("Rope " + (currentRope - 1));

        // If prevRope isn't null, set the connectedBody to the prevRope, and the anchor to the end of the prevRope
        if (prevRope != null)
        {
            joint.connectedBody = prevRope.GetComponent<Rigidbody>();
            joint.connectedAnchor = new Vector3(0, -0.8f, 0);
            return;
        }

        // Find the parent pole game object, set it to the connectedBody, and the anchor to the end of the rope
        joint.connectedBody = pole.GetComponent<Rigidbody>();
        joint.connectedAnchor = new Vector3(0, 1, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
