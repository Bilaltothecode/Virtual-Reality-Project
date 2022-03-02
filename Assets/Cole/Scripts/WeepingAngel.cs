using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingAngel : MonoBehaviour
{
    public Transform target;
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
        if (rend.isVisible)
        {
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
