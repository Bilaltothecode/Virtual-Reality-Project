using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VirtualCameraController : MonoBehaviour
{
    public Camera cameraCamera;
    public PostProcessVolume dofVolume, shutterSpeedVolume, isoVolume;
    public RenderTexture renderTexture;
    public GameObject photo;

    public TextMeshPro dofText, blurText, isoText, zoomText;

    public void AdjustFStop(bool up)
    {
        dofVolume.weight = Mathf.Clamp(dofVolume.weight + (up ? 0.1f : -0.1f), 0, 1);
        dofText.text = "FStop: " + dofVolume.weight.ToString();
    }

    public void AdjustShutterSpeed(bool up)
    {
        shutterSpeedVolume.weight = Mathf.Clamp(shutterSpeedVolume.weight + (up ? 0.1f : -0.1f), 0, 1);
        blurText.text = "Shutter: " + shutterSpeedVolume.weight.ToString();
    }

    public void AdjustISO(bool up)
    {
        isoVolume.weight = Mathf.Clamp(isoVolume.weight + (up ? 0.1f : -0.1f), 0, 1);
        isoText.text = "ISO: " + isoVolume.weight.ToString();
    }

    public void Zoom(bool up)
    {
        cameraCamera.fieldOfView = Mathf.Clamp(cameraCamera.fieldOfView + (up ? -10 : 10), 10, 90);
        zoomText.text = "FOV: " + cameraCamera.fieldOfView.ToString();
    }

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
