using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollower : MonoBehaviour
{
    GameObject handRoot;
    new Rigidbody rigidbody;

    void Start()
    {
        handRoot = transform.parent.gameObject;
        rigidbody = GetComponent<Rigidbody>();
        transform.parent = null;
    }

    void Update()
    {
        rigidbody.velocity = (handRoot.transform.position - transform.position).normalized * 10;
        float dist = Vector3.Distance(handRoot.transform.position, transform.position);
        if (Vector3.Distance(handRoot.transform.position, transform.position) < 0.1f)
            rigidbody.velocity *= dist * 10;
    }
}
