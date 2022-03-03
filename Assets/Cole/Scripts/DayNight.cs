using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Light sun;
    public Light moon;
    private bool isDay = true;
    private Light button;

    // Start is called before the first frame update
    void Start()
    {
        sun.enabled = true;
        moon.enabled = false;
        button = this.transform.Find("Button").GetComponent<Light>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdasd");
        if (other.gameObject.tag == "Controller")
        {
            if (isDay)
            {
                sun.enabled = false;
                moon.enabled = true;
                button.enabled = false;
                isDay = false;
                RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
                // Set skybox
                RenderSettings.skybox = Resources.Load("Assets/Oculus/Interaction/Runtime/Materials/UIUnderlayImposter") as Material;
            }
            else
            {
                sun.enabled = true;
                moon.enabled = false;
                button.enabled = true;
                isDay = true;
                RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
                // Set skybox
                RenderSettings.skybox = Resources.Load("Resources/unity_builtin_extras/Default-Skybox") as Material;
            }
        }
    }
}
