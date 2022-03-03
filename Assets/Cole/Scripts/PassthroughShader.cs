using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughShader : MonoBehaviour
{
    public GameObject[] objects;
    private OVRPassthroughLayer passthroughLayer;

    // Start is called before the first frame update
    void Start()
    {
        passthroughLayer = GetComponent<OVRPassthroughLayer>();
        foreach (GameObject obj in objects)
        {
            passthroughLayer.AddSurfaceGeometry(obj, true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
