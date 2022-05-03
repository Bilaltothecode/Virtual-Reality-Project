using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VirtualCameraController : MonoBehaviour
{
    public Camera cameraCamera;
    public RenderTexture renderTexture;
    public GameObject photo;

    public void TakePicture()
    {
        RenderTexture.active = renderTexture;
        Texture2D pictureTexture = new Texture2D(renderTexture.width, renderTexture.height);
        pictureTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        pictureTexture.Apply();

        GameObject newPhoto = Instantiate(photo);
        newPhoto.transform.position = transform.position;
        Material m = newPhoto.transform.Find("Render").GetComponent<MeshRenderer>().material;
        m.mainTexture = pictureTexture;

        StartCoroutine(PhotoFadeIn(m));
    }

    IEnumerator PhotoFadeIn(Material m)
    {
        yield return new WaitForSeconds(1);
        while (m.color.r < 0.99f)
        {
            m.color = Color.Lerp(m.color, Color.white, Time.deltaTime);
            yield return null;
        }
        m.color = Color.white;
    }
}
