using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchVibrate : MonoBehaviour
{
    public OVRInput.Controller controller;
    public Rigidbody rb;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    void Update()
    {
        //Debug.Log(Mathf.Min(rb.velocity.magnitude, 1f));
        //Debug.Log(rb.velocity.magnitude);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Controller")
        {
            StartCoroutine(Vibrate(controller));
        }
    }

    IEnumerator Vibrate(OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(0.5f, Mathf.Min(Mathf.Pow(OVRInput.GetLocalControllerVelocity(controller).magnitude, 2) / 2, 1f), controller);
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0f, 0f, controller);
    }
}
