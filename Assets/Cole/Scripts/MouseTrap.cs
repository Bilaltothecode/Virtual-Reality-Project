using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    private bool isTriggered = false;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.gameObject.tag == "Controller")
        {
            isTriggered = true;

            // Make the object a child of this, lock position
            // TODO let the controller wiggle lol
            other.transform.parent = transform;
            other.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
